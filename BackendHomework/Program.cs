using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BackendHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            //double profit, bonus = 0;

            //profit = Convert.ToInt32(Console.ReadLine());
            //double[] limits = { 100000, 200000, 400000, 600000, 1000000 };
            //double[] rates = { 0.1, 0.075, 0.05, 0.03, 0.015, 0.01 };
            //int level = 0;
            //for (int limi = 0; limi < (limits.Length - 1); limi++)
            //{
            //    if (profit >= limits[limi])
            //    {
            //        level += 1;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //if (level == 0)
            //{
            //    bonus = profit * 0.1;
            //}
            //else
            //{
            //    for (int i = 0; i < level - 1; i++)
            //    {
            //        bonus += rates[i] * limits[i];

            //    }
            //    bonus += profit - limits[level - 1] * rates[level]; 
            //}


            //Console.WriteLine($"bonus是{bonus}");

            //3-1 寫一程式，輸入10個整數，求其最小值。
            //int minValue = int.MaxValue;
            //int randomInt;
            //try
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("輸入10個數求最小值:");

            //        randomInt = Convert.ToInt32(Console.ReadLine());
            //        if (randomInt < minValue)
            //        {
            //            minValue = randomInt;
            //        }

            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("請輸入數字");

            //}
            //Console.WriteLine($"最小值為{minValue}");



            //3-2.寫一程式，輸入N個整數，求其最小值。
            //Console.WriteLine("請自行決定要輸入幾個數字");
            //int targetNumber = Convert.ToInt32(Console.ReadLine());
            //int minValue = int.MaxValue;
            //int randomInt;
            //for (int i = 0; i < targetNumber; i++)
            //{
            //    Console.WriteLine($"請輸入第{i + 1}個數字");
            //    randomInt = Convert.ToInt32(Console.ReadLine());
            //    if (randomInt < minValue)
            //    {
            //        minValue = randomInt;
            //    }
            //}
            //Console.WriteLine($"最小的數為{minValue}");
            //3-3.寫一程式，輸入10個整數，列出其中所有大於12的數字。

            //Console.WriteLine("輸入10個整數，列出其中所有大於12的數字");
            //string holder = "";
            //int randomInt;
            //int count = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"輸入第{i + 1}個數字");
            //    randomInt = Convert.ToInt32(Console.ReadLine());
            //    if (randomInt > 12)
            //    {
            //        holder += randomInt + " ";
            //        count += 1;
            //    }
            //}
            //if (count > 0)
            //{
            //    Console.WriteLine($"大於12的數字有{count}個");
            //    Console.WriteLine($"{holder}");
            //}
            //else
            //{
            //    Console.WriteLine("沒有任何數字大於12");
            //}

            //3-4.寫一程式，輸入10個整數，列出其中所有大於12的數字的總和。
            //Console.WriteLine("輸入10個整數");
            //int randomInt;
            //int holder = 0;
            //for(int i =0; i < 10; i++)
            //{
            //    Console.Write($"輸入第{i+1}個數字:");
            //    randomInt = Convert.ToInt32(Console.ReadLine());

            //    if (randomInt > 12)
            //    {
            //        holder += randomInt;
            //    }
            //}

            //Console.WriteLine($"大於12的數字總合為{holder}");

            //3-5.寫一程式，輸入N個數字，求其所有奇數中的最大值。例如輸入11,12,3,24,15，答案是15。
            //Console.WriteLine("請輸入你要輸入的上限");
            //int limit = Convert.ToInt32(Console.ReadLine());
            //int holder = int.MinValue;
            //bool hasOdd = false;
            //for (int i = 0; i < limit; i++)
            //{
            //    Console.WriteLine($"請輸入第{i+1}個數字");
            //    int target = Convert.ToInt32(Console.ReadLine());
            //    if (target % 2 != 0)
            //    {
            //        hasOdd = true;
            //        if (target > holder)
            //        {
            //            holder = target;
            //        }
            //    }
            //}
            //if (!hasOdd)
            //{
            //    Console.WriteLine("您並沒有輸入基數");
            //} else
            //{
            //    Console.WriteLine($"最大的基數為{holder}");
            //}

            //3-6.寫一程式，輸入N個數字，求其所有正數之平方的加總。
            //例如輸入1,-2,3,-4,5五個數字，得到
            //12 + (-2)2 + 32 + (-4)2 + 52 = 1 + 9 + 25 = 35
            //Console.WriteLine("請輸入上限:");
            //int limit = Convert.ToInt32(Console.ReadLine());
            //double holder = 0;
            //for (int i = 0; i < limit; i++)
            //{
            //    Console.WriteLine($"請輸入{i + 1}個數字:");
            //    int target = Convert.ToInt32(Console.ReadLine());
            //    if (target > 0)
            //    {
            //        holder += Math.Pow(target, 2);
            //    }
            //}

            //Console.WriteLine($"正數之平方的加總為{holder}");

            //3-7.寫一程式，輸入N個數字，其中有些是負數，
            //將這些負數轉換成正數，例如-7會被轉換成7。

            //Console.WriteLine("請輸入上限:");
            //int limit = Convert.ToInt32(Console.ReadLine());
            //StringBuilder holder = new StringBuilder();

            //for (int i = 0; i < limit; i++)
            //{
            //    int target = Convert.ToInt32(Console.ReadLine());
            //    holder.Append(Math.Abs(target)+" ");
            //}

            //Console.WriteLine(holder.ToString().Trim());

            //補充1.判斷101-200之間有多少個質數，並輸出所有質數。
            //string holder = "";
            //for (int i = 101; i <= 200; i++)
            //{
            //    int count = 0;
            //    for(int j =2; j <= 200; j++)
            //    {
            //        if (i%j == 0)
            //        {
            //            count++;
            //        }
            //    }
            //    if (count <2)
            //    {
            //        holder += i+" ";
            //    }
            //}
            //Console.WriteLine(holder);

            //2.輸入一個數，輸出其質因數
            //int num = Convert.ToInt32(Console.ReadLine());
            //StringBuilder primeFactor = new StringBuilder();
            //for (int i = 2; i < num; i++)
            //{
            //    if (num % i == 0)
            //    {
            //        int commonFactor = i;
            //        int count = 0;
            //        for (int j = 1; j < commonFactor; j++)
            //        {
            //            if (commonFactor % j == 0)
            //            {
            //                count++;
            //            }
            //        }

            //        if (count < 2)
            //        {
            //            Console.WriteLine(commonFactor);
            //        }

            //    }

            //}
            //3.求100到300中可以被3與7整除的個數。
            //int count = 0;
            //string target = "";
            //for (int i = 100; i <= 300; i++)
            //{
            //    if (i % 3 == 0 && i % 7 == 0)
            //    {

            //        target += i + " ";
            //        count++;
            //    }
            //}
            //Console.WriteLine($"100到300中可被3和7整除的個數有{count}個，分別為{target}");

            //4-1.利用while寫一程式求N個數字的最大值。
            //Console.WriteLine("輸入上限");
            //int n = Convert.ToInt32(Console.ReadLine());
            //int start = 0;
            //int maxValue = int.MinValue;
            //while (start < n)
            //{
            //    Console.WriteLine($"輸入第{start+1}個數字");
            //    int randomInt = Convert.ToInt32(Console.ReadLine());
            //    if (randomInt > maxValue)
            //    {
            //        maxValue = randomInt;
            //    }
            //    start++;
            //}
            //Console.WriteLine($"最大值為{maxValue}");

            //4-2.利用while寫一程式求一個等差級數數字的和，
            //一共有N個數字，程式應該輸入最小的起始值以及數字間的差。
            //(即從起始值開始，間格差，共N個 的總和)
            //Console.Write("輸入要幾個數字:");
            //int times = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入最小的數字:");
            //int start = Convert.ToInt32(Console.ReadLine());
            //int result=0;
            //Console.Write("輸入公差:");
            //int difference = Convert.ToInt32(Console.ReadLine());
            //int count = 0;
            //while(count < times)
            //{
            //    result += start;       // 先將當前的 `start` 加到 `result`
            //    Console.WriteLine(start);  // 輸出當前的數字
            //    start += difference;    // 再增加公差以取得下一個數字
            //    count++;
            //}
            //Console.WriteLine(result);

            //4-3.利用while寫一程式，讀入N個數字，
            //然後找出所有小於13的數，再求這些數字的和。
            //Console.Write($"請輸入上限:");
            //int limit = Convert.ToInt32(Console.ReadLine());
            //int count = 0;
            //int result = 0;
            //while (count < limit)
            //{
            //    Console.Write($"請輸入第{count+1}數字:");
            //    int check = Convert.ToInt32(Console.ReadLine());
            //    if (check < 13)
            //    {
            //        result += check;
            //    }
            //    count++;
            //}

            //Console.Write(result);

            //4-4.利用while寫一程式，讀入N個數字，
            //找到第一個大於7而小於10的數字就停止，而且列印出這個數字。
            //Console.Write("輸入上限:");
            //int limit = Convert.ToInt32(Console.ReadLine());
            //int count = 0;

            //while (count < limit)
            //{
            //    Console.Write($"請輸入第{count + 1}數字");
            //    int target = Convert.ToInt32(Console.ReadLine());
            //    if (target>7 && target<10)
            //    {
            //        Console.Write(target);
            //        break;
            //    }
            //    count++;
            //}

            //4-5.利用while寫一程式，讀入a1,a2,…,a5和b1,b2,…,b5。
            //找到第一個ai>bi，即停止，並列印出ai及bi。
            //int count = 0;
            //int[] aList = new int[5];
            //int[] bList = new int[5];
            //bool found = false;           
            //do
            //{               
            //    if (count >= 5)
            //    {
            //        Console.Write($"請輸入b{count -4}:");
            //        int b = Convert.ToInt32(Console.ReadLine());
            //        bList[count-5] = b;
            //        foreach (int a in aList)
            //        {
            //            if (a > b)
            //            {
            //                Console.WriteLine($"{a}{b}");
            //                found = true;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Console.Write($"請輸入a{count + 1}:");
            //        int a = Convert.ToInt32(Console.ReadLine());
            //        aList[count] = a;
            //    }
            //    count++;

            //} while (!found||count >=10);

            //1.Eric覺得麥蒂勞的39元漢堡實在太便宜、太好吃了，
            //因此他決定晚餐要把口袋裡所有錢通通拿來吃39元漢堡。
            //假設他每5分鐘就能吃一個漢堡，請隨意輸入一個時間，
            //輸出這段時間吃漢堡的紀錄。
            //Console.Write("以5分鐘為準，算吃了幾個漢堡，輸入一個時間:");
            //int time = Convert.ToInt32(Console.ReadLine());
            //int count = 0;
            //while (time>=5)
            //{
            //    count++;
            //    time -= 5;
            //}
            //Console.WriteLine(count);
            //2.小明貸款買房花560萬，每個月可還4萬，
            //每還12個月，因為年終獎金可以多還一萬，
            //請問需要幾個月還清。

            //int houseCost = 560;
            //int perMonth = 4;
            //int perYear = (perMonth * 12);
            //int extraPayment = 1;
            //int month = 0;
            //while(houseCost >= 0)
            //{
            //   if (houseCost <= 0)
            //    {
            //        break;
            //    }

            //    if (houseCost >= perYear)
            //    {
            //        houseCost -= perYear;
            //        houseCost -= extraPayment;
            //        month += 12;
            //    }
            //    else if (houseCost >= 0)
            //    {
            //        houseCost -= perMonth;
            //        month++;
            //    }
            //}

            //Console.WriteLine($"總共{ month}個月");

            //系統隨機產生一個數字，讓使用者數入數字，
            //直到猜中才離開程式！，猜錯時，要提示是比較大還是比較小。
            //int maxValue = int.MaxValue;
            //int minValue = int.MinValue;
            //Random random = new Random();
            //int ans = random.Next(minValue, maxValue);
            //int guess =0;
            //bool correct =false;
            //while (!correct)
            //{
            //    Console.Write($"請猜一個數字介於{minValue}和{maxValue}:");
            //    guess = Convert.ToInt32(Console.ReadLine());
            //    if (guess == ans)
            //    {
            //        Console.WriteLine("猜對了!");
            //        correct = true;
            //    }
            //    else if (guess > ans)
            //    {
            //        Console.WriteLine("太大了。");
            //        maxValue = guess;
            //    }
            //    else
            //    {
            //        Console.WriteLine("太小了。");
            //        minValue = guess;
            //    }
            //}
            //聖誕樹

            //Console.WriteLine("輸入聖誕樹高度:");
            //int size = Convert.ToInt32(Console.ReadLine()); 
            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = size; j > i; j--)
            //    {
            //        Console.Write(" ");
            //    }

            //    for (int k = 0; k < i; k++) { 
            //        Console.Write("*");
            //    }

            //    for (int l = 1; l < i; l++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();

            //}


            //for (int m =0; m < size/2; m++)
            //{
            //    for (int n = size-2; n>0; n--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int o= 0; o < 3; o++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //例題5.1-利用一維陣列求10個數字的計算平均值。
            //int[] num = new int[10];
            //int average=0;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"輸入{i+1}個數字");
            //    num[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //foreach(int x in num)
            //{
            //    average += x;
            //}


            //Console.WriteLine(average / num.Length);

            //例題5.2-利用一維陣列求10個數字的最大值。
            //int[] array = new int[10];
            //int maxNumber = int.MinValue;
            //for (int i =0, len = array.Length; i <len; i++)
            //{
            //    Console.WriteLine($"輸入第{i+1}個數字");
            //    array[i] = Convert.ToInt32(Console.ReadLine());

            //}

            //foreach(int x in array)
            //{
            //    if (x > maxNumber)
            //    {
            //        maxNumber = x;
            //    }
            //}
            //Console.WriteLine(maxNumber);

            //例題5.3-搜尋問題：輸入10個數字至A[ ]，再輸入x，
            //判斷x是否存在於A陣列中，如果存在，輸出所在的註標(索引)值，若不存在，則告知不存在
            //int[] array = new int[10];
            //int find;
            //for (int i = 0; i < 10; i++)
            //{
            //    array[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //Console.Write("請輸入想搜尋的值:");
            //find = Convert.ToInt32(Console.ReadLine());
            //int count = 0;
            //for (int i =0; i <10; i++)
            //{
            //    if (find == array[i])
            //    {
            //        Console.WriteLine($"符合搜尋數字的索引值為{i}");
            //        count++;
            //    }
            //}

            //if (count == 0)
            //{
            //    Console.WriteLine("搜尋的數字不存在於此陣列");
            //}


            //例題5.4求兩個2乘3的二維矩陣相加之結果，
            //第一個及第二個矩陣分別以A及B表示，相加之結果存入C矩陣，
            //最後將C矩陣內容顯示出來。

            //int[,] A = new int[2, 3];
            //int[,] B = new int[2, 3];
            //int[,] C = new int[2, 3];


            //for (int i =0; i < A.GetLength(0); i++)
            //{
            //    Console.Write("填入");
            //    Console.WriteLine($"第{i + 1}排");
            //    for (int j =0; j < A.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"第{j+1}列的數字");
            //        A[i,j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    Console.Write("填入");
            //    Console.WriteLine($"第{i + 1}排");
            //    for (int j = 0; j < B.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"第{j + 1}列的數字");
            //        B[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //for (int i = 0; i < C.GetLength(0); i++)
            //{
            //    Console.Write("填入");
            //    Console.WriteLine($"第{i + 1}排");
            //    for (int j = 0; j < C.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"第{j + 1}列的數字");
            //        C[i, j] = A[i, j] + B[i, j];
            //    }
            //}

            //for (int i = 0; i < C.GetLength(0); i++)
            //{
            //    for (int j = 0; j < C.GetLength(1); j++)
            //    {
            //        Console.WriteLine(C[i, j]);
            //    }
            //}

            //例題5.5-求2乘3的A矩陣乘以3乘1的B矩陣，
            //結果存入2乘1的C矩陣，最後將C矩陣的內容顯示出來。

            //int[,] A = new int[2,3];
            //int[,] B = new int[3,1];
            //int[,] C = new int[2, 1];

            //for (int i = 0; i <A.GetLength(0); i++)
            //{
            //    for (int j = 0; j < A.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"請輸入第{i+1}行第{j+1}列元素:");
            //        A[i, j] = Convert.ToInt32(Console.ReadLine());

            //    }
            //}



            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(1); j++)
            //    {
            //        Console.WriteLine($"請輸入第{i + 1}行第{j + 1}列元素:");
            //        B[i, j] = Convert.ToInt32(Console.ReadLine());

            //    }
            //}

            //for (int i =0; i < A.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(0); j++)
            //    {
            //        C[i, 0] += A[i, j] * B[j,0];
            //    }
            //}

            //for (int i =0; i < C.GetLength(0); i++)
            //{
            //    for (int j = 0; j < C.GetLength(1); j++)
            //    {
            //        Console.WriteLine(C[i, j]);
            //    }
            //}


            //5-5.寫一程式，將15數字存入3×5的二維陣列A中，
            //求每一行及每一列數字的最小值。

            //int[,] A = new int[3, 5];
            //TwoDimensionInput(A);
            //ShowTwoDimension(A);
            //ShowRowMin(A);
            //colMin(A);

            //5-6.寫一程式，輸入兩組數字：a1,a2,…,a5和b1,b2,…,b5。求ai+bi，i=1到i=5。
            //int len = 5;
            //int[] result = new int[len];
            //for (int i = 0; i < len; i++)
            //{
            //    Console.WriteLine($"輸入a{i+1}:");
            //    int a = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"輸入b{i+1}:");
            //    int b = Convert.ToInt32(Console.ReadLine());
            //    result[i] = a + b;
            //}
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine($"a{i + 1}+b{i + 1} = {result[i]}");
            //}


            //5-7.寫一程式，輸入兩組數字： a1,a2,…,a5和b1,b2,…,b5。
            //令x為a中的最大值，令y為b中的最大值，求x與y中較小者。
            //int len = 5;
            //int x = int.MinValue;
            //int y = int.MinValue;
            //for (int i =0; i < len; i++)
            //{
            //    Console.WriteLine($"輸入a{i+1}:");
            //    int a = Convert.ToInt32(Console.ReadLine());
            //    if (a > x)
            //    {
            //        x = a;
            //    }
            //    Console.WriteLine($"輸入b{i + 1}:");
            //    int b = Convert.ToInt32(Console.ReadLine());
            //    if (b > y)
            //    {
            //        y = b;
            //    }
            //}

            //if (x - y > 0)
            //{
            //    Console.WriteLine("x比較大");
            //} else
            //{
            //    Console.WriteLine("y比較大");
            //}

            //1.寫一個function 可以把一般對話框的文字轉成HTML。> 轉成 &gt; < 轉成 & lt; \r\n 轉成<br> | 轉成 &brvbar; 空白 轉成 &nbsp;
            //string example = @"Hans sagte: 'Gehe' > links <| und halt\r\n an.";
            //Console.WriteLine(ToHTML(example));

            //2.寫一個function，回傳輸入的值是否數字
            //Console.WriteLine(IsBool(123));
            //Console.WriteLine(IsBool(123.5));
            //Console.WriteLine(IsBool(true));
            //Console.WriteLine(IsBool("123"));
            //Console.WriteLine(IsBool(null));
            //Console.WriteLine(IsBool2("123"));
            ////3.寫一個function，回傳輸入的值是否符合Ｅ－ｍａｉｌ格式
            //Console.WriteLine(IsEmail("agmail.com"));
            ////4.寫一個function，回傳輸入的值是否符合手機格式
            //Console.WriteLine(IsCellPhone("09231"));
            ////5.回傳輸入的值是否符合身分證字號格式
            //Console.WriteLine(IsID("X20"));
            //6. 寫一個function，若輸入的文字大於Ｎ個，則超過的字不要，變成點點點
            //Console.WriteLine("輸入指定長度");
            //int len = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("輸入文字:");
            //string words = Console.ReadLine();
            //Console.WriteLine(checkLength(words, len));
            //7.寫一個function，輸入一個日期，把該日期轉成民國年.月.日格式
            //ChangeToTaiwanCalendar();

            //8.輸入一個日期，把把該日期轉成民國XX年XX月XX日 星期X 格式
            //Console.WriteLine(ChangeToTaiwanCalendarWithWeek(1991, 3, 29));

            //9.寫一個function，回傳輸入的年是否閏年(1992, 2024, 2000, 1993, 2005)
            //Console.WriteLine(IsLeapYear(1900));


            //----------------------字串---------------------------
            //1. 輸入姓名，輸出 Hi~輸入的姓名，比如說輸入Justin，輸出Hi~Justin。
            //Console.Write("輸入姓名:");
            //string name = Console.ReadLine();
            //Console.WriteLine(Hi(name));


            //2.請輸入任何一個字，是否出現在”
            //人人為我，我為人人、饒人不癡漢，癡漢不饒人”這個字串裡。
            //Console.WriteLine("請輸入任何一個字，是否出現在”人人為我，我為人人、饒人不癡漢，癡漢不饒人”這個字串裡。");
            //string quotation = "人人為我，我為人人、饒人不癡漢，癡漢不饒人";
            //string str = Console.ReadLine();
            //Console.WriteLine(detectString(str, quotation));

            //3.輸入一段字，輸出每個之間多一個-，如輸入apple ，輸出a-p-p-l-e。
            //Console.Write("輸入一段字，輸出每個之間多一個-，如輸入apple ，輸出a-p-p-l-e。");
            //string target = Console.ReadLine();
            //Console.WriteLine(dashWords(target));

            //4.輸入一個檔名輸出副檔名，如輸入apple.jpg，輸出jpg。

            //Console.WriteLine(extension("C#.txt"));
            //5.輸入一個大於五個字的單字，若小於五個字輸出長度不夠
            //，若大於五個字，則輸出前三個字。Length  Substring()
            //string target = "Maaa";
            //Console.WriteLine(substringFiveWords(target));

            //6.輸入一段字，輸出把輸入的一段字裡面的我，
            //改成小明，如輸入我在唱歌，輸出小明在唱歌。Replace()
            //Console.WriteLine(replaceLyrics("我在唱歌我在唱歌我在唱歌我在唱歌我在唱歌"));
            //7. 輸入一串字，顯示輸入幾個字。Length
            //Console.WriteLine(CheckStringLength("Holly Purple Cow."));
            //Console.WriteLine(CheckStringLength("我是神奇小寶。"));
            //8.連續輸入10組字，若沒輸入過，就顯示沒出現過，若輸入過，就顯示輸入過。
            //CheckIfAlreadyEntered10();
            //9.用字母大小寫來模擬波浪舞的動作後輸出，
            //比如輸入FiFa，輸出FifafIfafiFafifA
            //wave("Fifa");
            //10.輸入時間，顯示幾時幾分，例如輸入11:30，輸出11點30分。
            //Console.Write("輸入時間(ex:11:30):");
            //string t = Console.ReadLine();
            //Console.WriteLine(time(t));

            //11.輸入的字，轉成HTML，
            //例如輸入Justin,Amy,David 輸出<ul>
            //	<li>Justin<li>		<li>Amy<li>	<li>David<li></ul>
            //Console.Write(htmlUl("Justin,Amy,David"));
            //12. 輸入5處數字，用空白隔開，輸出結果。例如：輸入
            //‘11 19 12 25 1 7 12，輸出總和是87
            //Console.WriteLine(sumString("11 19 12 25 1 7 12"));
            //13. 輸入一串文字，倒著輸出，例如輸入：Justin，輸出nitsuJ
            //Console.WriteLine(reverse("Justin"));

            //Test join結果，可用一行顯示一為陣列內的值，Select可以搭配做出ulli的tag
            //    int[,] matrix = {
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 7, 8, 9 }
            //};

            //    int[] colSum = new int[matrix.GetLength(1)];
            //    for (int i = 0; i < matrix.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < matrix.GetLength(1); j++)
            //        {
            //            colSum[i]+=Convert.ToInt32(String.Join("", matrix[i, j]));
            //        }

            //    }
            //    for (int i = 0; i < matrix.GetLength(0); i++)
            //    {  
            //           Console.WriteLine( Convert.ToInt32(String.Join("", matrix[i, 0])));
            //    }
            //    Console.WriteLine(String.Join(" ", colSum));


            //寫一篇中文歌的歌詞到到自己指定的文字檔(使用UTF-8編碼)。
            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\lyrics.txt";
            //using (StreamWriter sw = File.CreateText(path))
            //{
            //    sw.WriteLine("馬爾濟斯");
            //    sw.WriteLine("馬爾濟斯;");
            //    sw.WriteLine("馬一濟二濟三濟四");
            //    sw.WriteLine("馬爾濟斯");
            //}

            //using (StreamReader reader = File.OpenText(path))
            //{
            //    string r;
            //    while ((r = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(r);
            //    }
            //}

            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\multiplyTable.txt";
            //using
            //    (StreamWriter writer = File.CreateText(path))
            //{
            //    for (int i = 1; i <= 9; i += 3)
            //    {
            //        for (int j = 1; j <= 9; j++)
            //        {
            //            for (int k = 0; k < 3; k++)
            //            {
            //                writer.Write($"{i + k} x {j} = {(i + k) * j}\t");
            //            }
            //            writer.WriteLine();
            //        }
            //        writer.WriteLine();

            //    }
            //}

            //string chinesePath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\ChineseMultiplierTable.txt";


            //using (StreamReader reader = File.OpenText(path))
            //{
            //    string r;
            //    using (StreamWriter writer = File.CreateText(chinesePath))
            //    {
            //        while ((r = reader.ReadLine()) != null)
            //        {
            //            r = r.Replace("0", "零").Replace("1", "壹").Replace("2", "貳").Replace("3", "參").Replace("4", "肆").Replace("5", "伍").Replace("6", "陸").Replace("7", "柒").Replace("8", "捌").Replace("9", "玖");

            //            writer.WriteLine(r);
            //        }
            //    }
            //}


            //string csvPath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\fc4bb.csv";
            //string savingPath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\index.html";
            //using (StreamReader reader = File.OpenText(csvPath))
            //{
            //    string r;
            //    using (StreamWriter writer = File.CreateText(savingPath))
            //    {
            //        int count = 0;
            //        int len = File.ReadAllLines(csvPath).Length;
            //        while ((r = reader.ReadLine()) != null)
            //        {
            //            string [] holder = r.Split(',');
            //            string tableData = String.Join("", holder.Select(h => "<td>" + h + "</td>"));
            //            tableData = "<tr>\n" + tableData + "</tr>\n";
            //            if (count == 0)
            //            {
            //                writer.WriteLine("<table>\n<thead>\n"  + tableData  + "</thead>\n");

            //            }
            //            else if (count == len - 1)
            //            {
            //                writer.WriteLine(tableData  + "</tbody>\n</table>\n");

            //            }
            //            else if (count == 1)
            //            {
            //                writer.WriteLine("<tbody>\n" +  tableData);
            //            }
            //            else
            //            {
            //                writer.WriteLine( tableData );

            //            }

            //            count++;

            //        }
            //        writer.WriteLine();

            //    }

            //}

            //請隨機由0~99產生一個數字輸出。
            //Random randomInt = new Random();
            //Console.WriteLine(randomInt.Next(0, 100));

            //請隨機由0~99產生10個數字輸出。
            //Random randomInt = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(randomInt.Next(0, 100));
            //}

            //隨機幫每位學員產生成績，並寫入文字檔(欄位之間用，分開，換行寫入下一筆)。
            //string gradePath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\grades.txt";
            //string[] students = { "楊雯茜", "鍾思瑩", "黃珮馨", "蔡東霖", "劉欣芸", "鄭柏易", "劉俊宏", "王誼楷", "江品學", "許雅琇", "陳郁婷", "翁梓航", "張子賢", "何宜駿", "鮑宥伶", "許喬雅" };
            //使用
            //楊雯茜,鍾思瑩,黃珮馨,蔡東霖,劉欣芸,鄭柏易,劉俊宏,王誼楷,江品學,許雅琇,陳郁婷,翁梓航,張子賢,何宜駿,鮑宥伶,許喬雅
            Random grades = new Random();
            //using(StreamWriter writer = File.CreateText(gradePath)){
            //    for (int i =0, len =students.Length; i < len; i++)
            //    {
            //        writer.WriteLine($"{students[i]} {grades.Next(0, 100)}"); 
            //    }
            //}

            //請設計樂透開獎程式。
            //Random lottery = new Random();
            //int[] playerNums = new int[7];
            //int[] lotteryResult = new int[6];
            //int count = 0;
            //int enterCount = 0;
            ////----------玩家輸入6個一般號和1個特別號----------------------
            //while (enterCount < 7)
            //{
            //    if (enterCount == 6)
            //    {
            //        Console.WriteLine("輸入特別號:");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"輸入你的第{enterCount + 1}個號碼");
            //    }
            //    int num = Convert.ToInt32(Console.ReadLine());
            //    if (num < 50 && num > 0 && !playerNums.Contains(num))
            //    {
            //        playerNums[enterCount] = num;
            //        count++;
            //    }
            //    else
            //    {
            //        Console.WriteLine("請輸入介於1-49之間的數字，並且不能重複");
            //        continue;
            //    }
            //    enterCount++;
            //}

            //////開獎--------------------------------------------------
            //for (int i = 0; i < 6; i++)
            //{
            //    lotteryResult[i] = lottery.Next(0, 50);
            //}
            //int[] lotteryResultCopy = (int[])lotteryResult.Clone();
            //////對比------------------------------------------------


            //foreach (int num in playerNums)
            //{
            //    count = 0;
            //    if (lotteryResultCopy.Contains(num))
            //    {
            //        int pos = Array.IndexOf(lotteryResultCopy, num);
            //        lotteryResultCopy[pos] = 0;
            //        count++;
            //    }
            //}


            ////結果-----------------------------------
            //if (count >= 6)
            //{
            //    Console.WriteLine("恭喜妳種了頭獎");
            //    Console.WriteLine(count);
            //}
            //else if (count >= 3)
            //{
            //    Console.WriteLine("恭喜中獎");
            //}
            //else
            //{
            //    Console.WriteLine("國庫空虛");
            //}
            //Console.WriteLine(String.Join(" ", lotteryResult));

            //請在文字檔裡輸入所有午餐的店家，讀取文字檔，隨機抽出今天中午要吃哪一家。
            //string lunchPath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\Lunch.txt";
            //string[] lunch = File.ReadAllLines(lunchPath, Encoding.GetEncoding("Big5"));
            //Random randomInt = new Random();
            //int rom = randomInt.Next(0, lunch.Length);
            //Console.WriteLine($"今天吃{lunch[rom]}");

            //請在文字檔裡輸入所有教室裡的學員名字，讀取文字檔，
            //隨機抽出今天的值日生，抽過不能再被抽中，直到全部學員都被抽過，才可以再被抽。
            //string dutyStudents = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\dutyPerson.txt";
            //string[] students = File.ReadAllLines(dutyStudents, Encoding.GetEncoding("Big5"));
            //Random randomInt = new Random();
            //string[] selected = new string[students.Length];
            //int count = 0;
            //while (count < students.Length)
            //{
            //    int rom = randomInt.Next(0,students.Length);
            //    if (selected.Contains(students[rom]))
            //    {
            //        continue;
            //    }
            //    selected[count] = students[rom];

            //    Console.WriteLine($"今天值日生是{students[rom]}");
            //    count++;
            //}


            //1.顯示現在日期與時間。
            //DateTime now = DateTime.Now;
            //Console.WriteLine(now);
            //2.顯示再過30天為哪一天。
            //DateTime now = DateTime.Now;
            //Console.WriteLine(now.AddDays(30));
            //3.顯示24小時前的年月日時分秒。
            //DateTime now = DateTime.Now;
            //Console.Write(now.AddHours(-24));
            //取得目前是幾月。
            //DateTime now = DateTime.Now;
            //Console.WriteLine(now.Month);
            //取得明年是否為閏年。(可以試試民國)
            //DateTime now = DateTime.Now;
            //DateTime nextYear = now.AddYears(1);
            //if (DateTime.IsLeapYear(nextYear.Year))
            //{
            //    Console.WriteLine("明年是閏年");
            //} else
            //{
            //    Console.WriteLine("明年不是閏年");
            //}
            //DateTime now = DateTime.Now;
            //TaiwanCalendar taiwanTime = new TaiwanCalendar();
            //int year = taiwanTime.GetYear(now);
            //Console.WriteLine(taiwanTime.IsLeapYear(year+1));
            //取得離2025年1月1日還有幾天。
            //DateTime now = DateTime.Now;
            //DateTime target = new DateTime(2025, 1, 1);
            //Console.Write((target - now).Days);

            //日期補充題1
            //DateTime now = DateTime.Now;
            //string dayOfWeek =Convert.ToString(now.DayOfWeek);
            //switch (dayOfWeek)
            //{
            //    case "Monday":
            //        Console.WriteLine("猴子穿新衣");
            //        break;
            //    case "Tuesday":
            //        Console.WriteLine("猴子肚子餓");
            //        break;
            //    case "Wednesday":
            //        Console.WriteLine("猴子去爬山");
            //        break;
            //    case "Thursday":
            //        Console.WriteLine("猴子看電視");
            //        break;
            //    case "Friday":
            //        Console.WriteLine("猴子去跳舞");
            //        break;
            //    case "Saturday":
            //        Console.WriteLine("猴子去斗六");
            //        break;
            //    case "Sunday":
            //        Console.WriteLine("猴子過生日");
            //        break;
            //}


            //輸入‘兩個日期，輸出兩個日期相差幾天。
            //DateTime date1 = new DateTime(2024, 11, 1);
            //DateTime date2 = new DateTime(2024, 11, 8);
            //Console.WriteLine((date2 - date1).Days);

            //補充習題-兩光法師
            DateTime start = new DateTime(2024, 1, 1);
            DateTime end = new DateTime(2024, 12, 31);
            int range = (end - start).Days + 1;
            Random randomInt = new Random();
            int randomDay = randomInt.Next(0, range);
            DateTime randomDate = start.AddDays(randomDay);

            int month = randomDate.Month;
            int day = randomDate.Day;
            int S = (month * 2 + day) % 3;
            Console.WriteLine(randomDay);
            switch (S)
            {
                case 0:
                    Console.WriteLine("普通");
                    break;
                case 1:
                    Console.WriteLine("吉");
                    break;
                case 2:
                    Console.WriteLine("大吉");
                    break;
            }

            Console.ReadKey();

        }
        public static string reverse(string str)
        {
            return String.Join("", str.Reverse());
            //join就是C#的list?如果有一坨東西丟進去看看
        }
        public static int sumString(string content)
        {
            int result = 0;
            string[] str = content.Split(' ');
            for (int i = 0; i < str.Length; i++)
            {
                result += Convert.ToInt32(str[i]);
            }

            return result;
        }

        public static string htmlUl(string str)
        {
            string result = "";
            string[] strList = str.Split(',');
            result = "<ul>\n" + String.Join("", strList.Select(s => "<li>" + s + "</li>\n")) + "</ul>";
            return result;
        }
        public static string time(string t)
        {
            string result = t;

            return result.Replace(":", "點") + "分";
        }

        public static void wave(string str)
        {
            string lowerStr = str.ToLower();
            char[] target = lowerStr.ToCharArray();
            int len = target.Length;
            for (int i = 0; i < len; i++)
            {
                int targetNum = (int)target[i] - 32;
                target[i] = Convert.ToChar(targetNum);
                string result = String.Join("", target);
                Console.WriteLine(result);
                target[i] = Convert.ToChar((int)target[i] + 32);
            }
        }

        public static void CheckIfAlreadyEntered10()
        {
            string[] entered = new string[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("輸入一些字:");
                string check = (string)Console.ReadLine();
                if (entered.Contains(check))
                {
                    Console.WriteLine("有出現過");
                }
                else
                {
                    Console.WriteLine("沒出現過");
                }
                entered[i] = check;
            }
        }

        public static int CheckStringLength(string str)
        {
            int len;
            string check = str.Replace(".", "").Replace("，", "").Replace(",", "").Replace("。", "");
            Console.WriteLine(check);
            if (check.Contains(" "))
            {
                len = check.Split(' ').Length;
            }
            else
            {
                len = check.Length;
            }


            return len;
        }
        public static string replaceLyrics(string lyrics)
        {
            string result;
            result = lyrics.Replace("我", "小明");
            return result;
        }
        public static string substringFiveWords(string str)
        {
            string result = "";
            if (str.Length < 5)
            {
                result = "輸出長度不夠";
            }
            else
            {
                result = str.Substring(0, 3);
            }

            return result;
        }
        public static string extension(string words)
        {
            string result = words;

            Console.WriteLine(result.IndexOf('.'));
            int dotIndex = result.IndexOf('.');
            result = result.Substring(dotIndex + 1);

            return result;
        }
        public static string dashWords(string words)
        {
            string result = words;
            char[] r = result.ToCharArray();
            result = String.Join("-", r);
            return result;
        }
        public static string detectString(string str, string quo)
        {
            string result;
            if (quo.Contains(str))
            {
                result = "有包含";
            }
            else
            {
                result = "未包含";
            }
            return result;
        }
        public static string Hi(string str)
        {
            return $"Hi~{str}";
        }
        public static string IsLeapYear(int year)
        {
            Console.WriteLine(DateTime.IsLeapYear(year));
            string result;
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                result = "是閏年";
            }
            else
            {
                result = "不是閏年";
            }
            return result;
        }
        public static string ChangeToTaiwanCalendarWithWeek(int year, int month, int day)
        {
            DateTime dateTime = new DateTime(year, month, day);
            TaiwanCalendar taiwancalendar = new TaiwanCalendar();
            int y = taiwancalendar.GetYear(dateTime);
            int m = taiwancalendar.GetMonth(dateTime);
            int d = taiwancalendar.GetDayOfMonth(dateTime);
            string w = Convert.ToString(taiwancalendar.GetDayOfWeek(dateTime));
            string weekofday = "";
            switch (w)
            {
                case "Monday":
                    weekofday = "星期一";
                    break;
                case "Tuesday":
                    weekofday = "星期二";
                    break;
                case "Wednesday":
                    weekofday = "星期三";
                    break;
                case "Thursday":
                    weekofday = "星期四";
                    break;
                case "Friday":
                    weekofday = "星期五";
                    break;
                case "Saturday":
                    weekofday = "星期六";
                    break;
                case "Sunday":
                    weekofday = "星期天";
                    break;
            }

            return $"{y}/{m}/{d} {weekofday}";
        }
        public static string ChangeToTaiwanCalendar()
        {
            DateTime dateTime = new DateTime(1993, 3, 1);
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            int year = taiwanCalendar.GetYear(dateTime);
            int month = taiwanCalendar.GetMonth(dateTime);
            int day = taiwanCalendar.GetDayOfMonth(dateTime);
            string result = $"{year}/{month}/{day}";
            return result;
        }
        public static string checkLength(string value, int len)
        {
            string transformedString = value;
            if (value.Length > len)
            {
                transformedString = transformedString.Substring(0, len) + "...";
            }

            return transformedString;
        }
        public static string IsID(string value)
        {
            string result = "";
            string pattern = @"^[A-Za-z]+\d{9}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(value))
            {
                result = "這是身分證";
            }
            else
            {
                result = "這不是身分證";
            }
            return result;
        }

        public static string IsCellPhone(string value)
        {
            string result = "";
            string pattern = @"^(09)\d{8}|09\d{2}-\d{3}-\d{3}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(value))
            {
                result = "這是手機";
            }
            else
            {
                result = "這不是手機";
            }
            return result;
        }
        public static string IsEmail(string value)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string result = "";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(value))
            {
                result = "這是email";
            }
            else
            {
                result = "這不是email";
            }


            return result;
        }
        public static bool IsBool2(string value)
        {
            string pattern = @"^\d+$";
            Regex regex = new Regex(pattern);
            bool result = regex.IsMatch(value);
            return result;
        }
        public static string IsBool(object value)
        {
            //getType 和typeof一起判斷類別
            //或可以直接用is
            //string result = "輸入值為數字";
            if (value != null && value is int || value is double || value is float || value is decimal)
            {
                return "輸入值為數字";
            }
            else
            {
                return "輸入值不是數字";
            }
        }

        public static string ToHTML(string sentence)
        {
            string transformedText = "";
            transformedText = sentence.Replace(">", "&gt;")
                .Replace("<", "&lt;")
                .Replace("\r\n", "<br>")
                .Replace("|", "&brvbar")
                .Replace(" ", "&nbsp;");
            return transformedText;
        }


        public static void TwoDimensionInput(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"請輸入第{i + 1}第{j + 1}列的數字:");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public static void ShowTwoDimension(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine(arr[i, j]);
                }
            }
        }

        public static void ShowRowMin(int[,] arr)
        {
            int[] rowMin = new int[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int minValue = int.MaxValue;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < minValue)
                    {
                        minValue = arr[i, j];
                    }
                }
                rowMin[i] = minValue;
            }

            for (int i = 0; i < rowMin.GetLength(0); i++)
            {
                Console.WriteLine($"第{i}行的最小值為{rowMin[i]}");
            }
        }

        public static void colMin(int[,] arr)

        {
            int[] colMin = new int[arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int minValue = int.MaxValue;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < minValue)
                    {
                        minValue = arr[j, i];
                    }
                }
                colMin[i] = minValue;

            }

            for (int i = 0; i < colMin.GetLength(0); i++)
            {
                Console.WriteLine($"第{i}列的最小值為{colMin[i]}");
            }
        }
    }
}
