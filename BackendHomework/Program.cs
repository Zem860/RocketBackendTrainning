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

namespace BackendHomework
{
    internal class Program
    {   



        static void Main(string[] args)
        {
            //1.寫一個function 可以把一般對話框的文字轉成HTML。> 轉成 & gt; < 轉成 & lt; \r\n 轉成<br> | 轉成 & brvbar; 空白 轉成 &nbsp;
            //Program programInstance = new Program(); // 創建 Program 類的實例
            //string str = "Hello > world";
            //string test = programInstance.ToHTML(str);
            //Console.WriteLine(test);

            //2.寫一個function，回傳輸入的值是否數字
            //Console.Write("請隨意輸入，我會判斷這是否為數字:");
            //string input = Console.ReadLine();
            //Console.WriteLine(CheckIsNumber(input));

            //3.寫一個function，回傳輸入的值是否符合Ｅ－ｍａｉｌ格式
            //Console.WriteLine("輸入email，我會判斷是否符合email格式");
            //string input = Console.ReadLine();
            //Console.WriteLine(CheckIsEmail(input));

            //4.寫一個function，回傳輸入的值是否符合手機格式
            //Console.Write("輸入台灣格式的手機號碼，我會檢查格式是否正確09xx-xxx-xxx:");
            //string input = Console.ReadLine();
            //Console.WriteLine(CheckIsCellphone(input));

            //5.回傳輸入的值是否符合身分證字號格式
            //Console.Write("輸入台灣格式身分證字號，我會檢查格式是否正確:");
            //string input = Console.ReadLine();
            //Console.WriteLine(CheckIsId(input));

            //6. 寫一個function，若輸入的文字大於Ｎ個，則超過的字不要，變成點點點
            //Console.Write("指定文字長度:");
            //int len = Convert.ToInt32(Console.ReadLine());
            //Console.Write("請輸入文字:");
            //string text = Console.ReadLine();
            //Console.WriteLine(ShortenContent(text, len));

            //7. 寫一個function，輸入一個日期，把該日期轉成民國年.月.日格式
            //Console.Write("輸入年:");
            //int year = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入月:");
            //int month = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入日:");
            //int day = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(ConvertToROCyear(year, month, day));
            //Console.ReadKey();

            //8.輸入一個日期，把把該日期轉成民國XX年XX月XX日 星期X 格式
            //Console.Write("輸入西元年:");
            //int year = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入月份:");
            //int month = Convert.ToInt32(Console.ReadLine());
            //Console.Write("輸入日:");
            //int day = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(ConvertToTaiwanCalendarWithDayOfWeek(year, month, day));

            //9.寫一個function，回傳輸入的年是否閏年(1992, 2024, 2000, 1993, 2005)
            //Console.Write("請輸入年分，我可以判斷當年是否為閏年:");
            //int year = Convert.ToInt32(Console.ReadLine());
            //bool isLeapYear = CheckIsLeapYear(year);
            //string result = isLeapYear ? "是" : "不是";
            //Console.WriteLine($"{year}{result}閏年");

            //10.寫一個function，輸入手機號碼，回傳今天運勢(手機運勢算法：
            //用你的手機號碼的最後四位數除以80，再減去整數部分（只留小數），
            //再乘以80，就會得到一個數，這就是代表吉凶的數字，印出結果。)
            Console.WriteLine("輸入您的手機號碼(不需要-):");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine(FortuneNumber(phoneNumber));
            Console.ReadKey();

        }


        static double FortuneNumber(string number)
        {

            int len = number.Length;
            int needLength = len - 4;
            double lastFourNumber = Convert.ToDouble(number.Substring(needLength));
            double baseNum = lastFourNumber / 80;
            double integerPart = Math.Floor(baseNum);
            double fractionalPart = baseNum - integerPart;
            double result = fractionalPart *80;
            return result;
        }

         static bool CheckIsLeapYear(int year)
        {
            if  ((year%4 ==0 && year%100!=0 )||(year %400==0))
            {
                return true;
            }

            return false;
        }
        static string ConvertToTaiwanCalendarWithDayOfWeek(int y, int m, int d)
        {
           //轉成台灣時間的時候會有一天的誤差所以把星期寫在前面
            DateTime date = new DateTime(y, m, d);
            string weekday = "";
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    weekday = "星期日";
                    break;
                case DayOfWeek.Monday:
                    weekday = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    weekday = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    weekday = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    weekday = "星期四";
                    break;
                case DayOfWeek.Friday:
                    weekday = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    weekday = "星期六";
                    break;
            }
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            date = new DateTime(y, m, d, taiwanCalendar);
            int year = taiwanCalendar.GetYear(date);
            int month = taiwanCalendar.GetMonth(date);
            int day = taiwanCalendar.GetDayOfMonth(date);
            return $"民國{year}年{month}月{day}日{weekday}";
        }


        static string ConvertToROCyear(int year, int month, int day)
        {
            int newYear = year - 1911;
            int[] date = {newYear, month, day};
            string result = string.Join(".", date);
            return result;
        }
        static string ShortenContent(string text, int len)
        {
            string result = "";
            string[] stringList = text.Split();
            if (stringList.Length > len)
            {
                for (int s = 0; s < len; s++)
                {
                    if (s == len - 1)
                    {
                        result += stringList[s]+"...";
                        break;
                    }
                    result += stringList[s] + " ";
                }
                
            }
            return result;
        }
        static bool CheckIsId(string input)
        {
            string pattern = "^[A-Za-z][1-2]\\d{8}$";
            Regex checker = new Regex(pattern);
            return checker.IsMatch(input);
        }
        static bool CheckIsCellphone(string input)
        {
            string pattern = @"^(09)\d{8}|09\d{2}-\d{3}-\d{3}$";
            //@不用\表示忽略
            //|可選擇前面和後面的格式
            Regex checker = new Regex(pattern);
            return checker.IsMatch(input);
        }
        static bool CheckIsEmail(string input)
        {
            string pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
            Regex checker = new Regex(pattern);
            return checker.IsMatch(input);
        }
        static bool CheckIsNumber(string input)
        {
            string pattern = @"^\d+$";
            Regex checker = new Regex(pattern);
            return checker.IsMatch(input);
        }
        string ToHTML(string str)
        {
            string[,] targets = { { ">", "<", "\\r\\n", "|", " " }, { "&gt; ", "&lt;", "<br>", "&brvbar;", "&nbsp;" } };

            string result = str;
            for (int j = 0; j < targets.GetLength(1); j++)
            {
                string target = targets[0, j];
                result = result.Replace(target, targets[1, j]);

            }
            return result;
        }
    }
}
