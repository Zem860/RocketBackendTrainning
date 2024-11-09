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
using System.Runtime.CompilerServices;
using System.Data;

namespace BackendHomework
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //----------------檔案-----------------------
            //1.寫一篇中文歌的歌詞到到自己指定的文字檔(使用UTF-8編碼)。
            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\lyrics.txt";
            //while (true) {
            //    Console.WriteLine("輸入歌詞，不輸入的話輸入stop");
            //    string line = Console.ReadLine();

            //    if (line == "stop")
            //    {
            //        break;
            //    }
            //    File.AppendAllText(path, line+Environment.NewLine);

            //}

            //2.讀取1.txt 顯示在畫面上。
            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\1.txt";
            //string[] content = File.ReadAllLines(path);
            //foreach(string line in content)
            //{
            //    Console.WriteLine(line);
            //}

            //3. 把99乘法表寫入某個檔案裏面

            //for (int i =1; i <= 9; i += 3)
            //    //左邊起始1 4 7
            //{
            //    for (int j = 1; j <= 9; j++)
            //    {
            //        //確定可以左邊那排乘以147x9
            //        for (int k = 0; k <= 2; k++)
            //        {
            //            //把右邊剩餘的補滿，每row做3次

            //            Console.Write($"{i + k} x {j}= {(i + k) * j}\t");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}

            //string filePath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\1.txt";

            //using (StreamWriter writer = new StreamWriter(filePath))
            //{

            //    for (int i = 1; i <= 9; i += 3)
            //    //左邊起始1 4 7
            //    {
            //        for (int j = 1; j <= 9; j++)
            //        {
            //            //確定可以左邊那排乘以147x9
            //            for (int k = 0; k <= 2; k++)
            //            {
            //                //把右邊剩餘的補滿，每row做3次

            //                writer.Write($"{i + k} x {j}= {(i + k) * j}\t");
            //            }
            //            writer.WriteLine();
            //        }
            //        writer.WriteLine();
            //    }
            //}

            //讀取1.txt 顯示在畫面上，並將1.txt 裡的阿拉伯數字，轉換成中文數字(壹、貳、叁、肆…..)，並儲存到指定的路徑。(UTF-8)
            //string filePath = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\1.txt";
            //string destination = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\2.txt";
            //string text = File.ReadAllText(filePath, Encoding.UTF8);
            //char[] words = { '壹', '貳','參','肆','伍','陸','柒','捌', '玖' };
            //text = text.Replace("1", "壹")
            //       .Replace("2", "貳")
            //       .Replace("3", "參")
            //       .Replace("4", "肆")
            //       .Replace("5", "伍")
            //       .Replace("6", "陸")
            //       .Replace("7", "柒")
            //       .Replace("8", "捌")
            //       .Replace("9", "玖")
            //       .Replace("0", "零");
            //using (StreamWriter writer = new StreamWriter(destination))
            //{
            //    writer.Write(text);
            //}

            //讀取fc4bb.csv，並將此資料轉成HTML TABLE 格式，並儲存到指定的HTML檔裡。
            string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\fc4bb.csv";
            string destination = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\index.html";
            string[] contentArr = File.ReadAllLines(path, Encoding.UTF8);
            string[,] tags = { { "<table>", "</table>" }, { "<td>", "</td>" }, { "<tr>", "</tr>" }, { "<thead>", "</thead>" }, { "<tbody>", "</tbody>" } };
            string result = "";
            for (int i = 0; i < contentArr.Length; i++)
            {
                string[] dataRow = contentArr[i].Split(',');
                int len = dataRow.Length;

                for (int j = 0; j < len; j++)
                {
                    dataRow[j] = tags[1, 0] + dataRow[j] + tags[1, 1];
                }
                if (i == 0)
                {
                    contentArr[i] = tags[0, 0] + Environment.NewLine + tags[3, 0] + tags[2, 0] + String.Join("", dataRow) + tags[2, 1] + tags[3, 1];
                }
                else if (i == 1)
                {
                    contentArr[i] = tags[4, 0] + tags[2, 0] + String.Join("", dataRow) + tags[2, 1];
                }
                else if (i == contentArr.Length - 1)
                {
                    contentArr[i] = tags[2, 0] + String.Join("", dataRow) + tags[2, 1] + tags[4, 1] + Environment.NewLine + tags[0, 1];
                }

                else
                {
                    contentArr[i] = tags[2, 0] + String.Join("", dataRow) + tags[2, 1];
                }

            }
            result = String.Join("", contentArr);

            File.WriteAllText(destination, result
                );


            //-------------------------亂數------------------------------
            //請隨機由0~99產生一個數字輸出。
            //Random rom = new Random();//亂數種子int I = rom.Next(0, 100);//回傳0-99的亂數




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
            DateTime thisYearEnd = new DateTime(2024, 12, 31);
            DateTime thisYearStart = new DateTime(2024, 1, 1);
            TimeSpan thisYearRange = thisYearEnd - thisYearStart;
            long range = (long)thisYearRange.Ticks;
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
            Console.WriteLine($"亂數為{num.Next(1, 3)}");
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

            for (int i = 0; i < target.Length; i++)
            {
                for (int j = 0; j < target.Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write((char)((int)target[j] - 32));
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
