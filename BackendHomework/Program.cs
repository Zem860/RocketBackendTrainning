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

namespace BackendHomework
{
    internal class Program
    {   

        static void Main(string[] args)
        {
            string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\test.txt";
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
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            Console.WriteLine($"今年 {year}年 {month}月 {day}日 {hour}時:{minute}分:{second}秒");
            
            

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
