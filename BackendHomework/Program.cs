using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
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
            int len = 5;
            int x = int.MinValue;
            int y = int.MinValue;
            for (int i =0; i < len; i++)
            {
                Console.WriteLine($"輸入a{i+1}:");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a > x)
                {
                    x = a;
                }
                Console.WriteLine($"輸入b{i + 1}:");
                int b = Convert.ToInt32(Console.ReadLine());
                if (b > y)
                {
                    y = b;
                }
            }

            if (x - y > 0)
            {
                Console.WriteLine("x比較大");
            } else
            {
                Console.WriteLine("y比較大");
            }

            Console.ReadKey();

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

        public static void colMin(int[,]arr)
            
        {
            int[] colMin = new int[arr.GetLength(1)];
            
            for (int i = 0; i <arr.GetLength(1); i++)
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
