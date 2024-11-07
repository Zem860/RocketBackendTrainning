using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace BackendHomework
{
    internal class Program
    {   

        static void Main(string[] args)
        {

            //----------------日期-----------------------
            //1. 顯示現在日期與時間。
            //DateTime currentTime = DateTime.Now;
            //Console.WriteLine(currentTime);

            //2.顯示再過30天為哪一天
            //DateTime curTime = DateTime.Now;
            //DateTime after30Day =  currentTime.AddDays(30);
            //Console.WriteLine($"今天是{curTime}再過30天是{after30Day}");

            //3.顯示24小時前的年月日時分秒。
            //DateTime curTime = DateTime.Now;
            //curTime = curTime.AddHours(-24);
            //int year = curTime.Year;
            //int month = curTime.Month;
            //int day = curTime.Day;
            //int hour = curTime.Hour;
            //int mins = curTime.Minute;
            //int secs = curTime.Second;
            //Console.WriteLine($"24小時前的年月日時分秒為{year}/{month}/{day} {hour}:{mins}:{secs}");

            //4.取得目前是幾月
            //DateTime curTime = DateTime.Now;
            //int curMonth = curTime.Month;
            //Console.WriteLine($"目前是{curMonth}月");

            //5.取得明年是否為閏年。(可以試試民國)
            //DateTime curTime = DateTime.Now;
            //DateTime nextYearTime = curTime.AddYears(1);
            //int nextYear = nextYearTime.Year;
            //bool isLeapYear = DateTime.IsLeapYear(nextYear);
            //if (isLeapYear)
            //{
            //    Console.WriteLine("明年是閏年");
            //} else
            //{
            //    Console.WriteLine("明年不是閏年");
            //}

            //5.取得明年是否為閏年。(可以試試民國)
            //TaiwanCalendar taiwanTime = new TaiwanCalendar();
            //DateTime curTime = DateTime.Now;
            ////DateTime nextnextYear = curTime.AddYears(2); //測試其他年會不會出錯
            //bool isLeapYear = taiwanTime.IsLeapYear(taiwanTime.GetYear(curTime));
            //switch (isLeapYear)
            //{
            //    case true:
            //        Console.WriteLine("今年是閏年");
            //        break;
            //    default:
            //        Console.WriteLine("今年不是是閏年");
            //        break;
            //}

            //6. 取得離2025年1月1日還有幾天。
            //DateTime targetDateTime = new DateTime(2025, 1, 1);
            //DateTime curTime = DateTime.Now;
            //int remainDays = targetDateTime.Subtract(curTime).Days;
            //Console.WriteLine($"離2025年1月1日剩下{remainDays}天");

            //日期補充提
            //請顯示今天猴子做甚麼事。
            //DateTime date = DateTime.Now;
            //date= date.AddDays(5);//測試
            //string weekday = date.DayOfWeek.ToString();
            //switch (weekday)
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
            //Console.WriteLine("輸入第一個日期");
            //Console.WriteLine("年:");
            //int year1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("月:");
            //int month1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("日:");
            //int day1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("輸入第二個日期");
            //Console.WriteLine("年:");
            //int year2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("月:");
            //int month2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("日:");
            //int day2 = Convert.ToInt32(Console.ReadLine());
            //DateTime date1 = new DateTime(year1,month1,day1);
            //DateTime date2 = new DateTime(year2,month2,day2);
            //TimeSpan differencesTimeSpan = date1.Subtract(date2);
            //double differences = Math.Abs(differencesTimeSpan.TotalDays);
            //Console.WriteLine($"第一個日期和第二個日期差了{differences}天");

            //算命師的那題
            DateTime thisYearEnd = new DateTime(2024, 12,31);
            DateTime thisYearStart = new DateTime(2024, 1, 1);
            TimeSpan thisYearRange = thisYearEnd - thisYearStart;
            long range =(long)thisYearRange.Ticks;
            Random rnd = new Random();
            double javascriptMathRandom = rnd.NextDouble();
            double randomTicks = range * javascriptMathRandom;
            DateTime randomTime = thisYearStart.AddTicks((long)randomTicks);
            int rndMonth = randomTime.Month;
            int rndDay = randomTime.Day;
            //S=(M*2+D)%3
            int S = ((rndMonth * 2) + rndDay) % 3;
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






            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\test.txt";
            //string createText = "麻ㄚㄚ";
            //string[] createLines = {"米蒂","咪喵","麻ㄚㄚ" };
            //string[] createLines2 = { "利可", "雷古", "娜娜奇" };
            //string appendText = "殲滅卿";

            ////File.WriteAllLines(path, createLines2);
            //File.AppendAllText(path, appendText);
            //string a = File.ReadAllText(path);
            //string[] a = File.ReadAllLines(path);
            //Process.Start(path);
            //開檔案(路徑)
            //foreach(string x in a)
            //{
            //    Console.WriteLine(x);
            //}

            //Next()沒範圍
            Random num = new Random();
            Console.WriteLine($"亂數為{num.Next(1,3)}");
            Console.ReadKey();

            ////Next(Int32, Int32)指定範圍
            //Random num = new Random();
            //int randomnum = num.Next(1, 50);
            //Console.WriteLine($"亂數為{randomnum}");

            //1.取得日期及時間
            //寫法(一)
            DateTime a = DateTime.Now;
            Console.WriteLine($"今年 {a.Year}年 {a.Month}月 {a.Day}日 {a.Hour}時:{a.Minute}分:{a.Second}秒");
            
            //寫法(二)
            //DateTime now = DateTime.Now;
            //int year = now.Year;
            //int month = now.Month;
            //int day = now.Day;
            //int hour = now.Hour;
            //int minute = now.Minute;
            //int second = now.Second;
            //Console.WriteLine($"今年 {year}年 {month}月 {day}日 {hour}時:{minute}分:{second}秒");
            
            

            //2.DateTime.Today 今天日期
            DateTime b = DateTime.Today;
            Console.WriteLine($"今天是{b}");
            #region
            //3.DayOfWeek今天是禮拜幾(英文呈現)
            //DateTime week = DateTime.Today;
            //DayOfWeek todayweek = week.DayOfWeek;
            //Console.WriteLine($"今天是{todayweek}");
            //Console.ReadKey();

            //寫法(二)
            DateTime week = DateTime.Today;
            Console.WriteLine($"今天是{week.DayOfWeek}");

            //賦值給變數 today
            DateTime today = DateTime.Today;
            //賦值給變數 happyday 
            DateTime happyday = new DateTime(today.Year, 4, 26);
            //計算天數差
            int next = (int)(happyday - today).TotalDays;
            Console.WriteLine($"今天是{today:yyyy年MM月dd日}，距離4/26還有{next}天");
            #endregion

            //demo();
            //Program pro = new Program();
            //pro.demo2();

            string target = "fifa";

            for (int i =0; i<target.Length; i++)
            {
                for (int j = 0; j < target.Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write((char)((int)target[j]-32));
                    }
                    else
                    {
                        Console.Write(target[j]);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static void demo()
        {
            Console.WriteLine("demo");
        }

        public void demo2()
        {
            Console.WriteLine("demo2");
        }
    }
}
