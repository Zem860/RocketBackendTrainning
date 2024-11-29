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
            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\fc4bb.csv";
            //string destination = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\index.html";
            //string[] contentArr = File.ReadAllLines(path, Encoding.UTF8);
            //string[,] tags = { { "<table>", "</table>" }, { "<td>", "</td>" }, { "<tr>", "</tr>" }, { "<thead>", "</thead>" }, { "<tbody>", "</tbody>" } };
            //string result = "";
            //for (int i = 0; i < contentArr.Length; i++)
            //{
            //    string[] dataRow = contentArr[i].Split(',');
            //    int len = dataRow.Length;

            //    for (int j = 0; j < len; j++)
            //    {
            //        dataRow[j] = tags[1, 0] + dataRow[j] + tags[1, 1];
            //    }
            //    if (i == 0)
            //    {
            //        contentArr[i] = tags[0, 0] + Environment.NewLine + tags[3, 0] + tags[2, 0] + String.Join("", dataRow) + tags[2, 1] + tags[3, 1];
            //    }
            //    else if (i == 1)
            //    {
            //        contentArr[i] = tags[4, 0] + tags[2, 0] + String.Join("", dataRow) + tags[2, 1];
            //    }
            //    else if (i == contentArr.Length - 1)
            //    {
            //        contentArr[i] = tags[2, 0] + String.Join("", dataRow) + tags[2, 1] + tags[4, 1] + Environment.NewLine + tags[0, 1];
            //    }

            //    else
            //    {
            //        contentArr[i] = tags[2, 0] + String.Join("", dataRow) + tags[2, 1];
            //    }
            //}
            //result = String.Join("", contentArr);

            //File.WriteAllText(destination, result
            //    );


            //-------------------------亂數------------------------------
            //請隨機由0~99產生一個數字輸出。
            //Random rom = new Random();
            //Console.WriteLine(rom.Next(0, 100));
            ////請隨機由0~99產生10個數字輸出。
            //Console.WriteLine("---------------------------");
            //Random randomInt = new Random();
            //for (int i =0, len = 10; i < len; i++)
            //{   
            //    Console.WriteLine(randomInt.Next(0,100));
            //}

            //隨機幫每位學員產生成績，並寫入文字檔(欄位之間用，分開，換行寫入下一筆)。
            //path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\studentGrades.txt";
            //string[] students = { "楊雯茜", "鍾思瑩", "黃珮馨", "蔡東霖", "劉欣芸", "鄭柏易", "劉俊宏", "王誼楷", "江品學", "許雅琇", "陳郁婷", "翁梓航", "張子賢", "何宜駿", "鮑宥伶", "許喬雅" };
            //Random grade = new Random();
            //for (int i = 0; i<students.Length; i++)
            //{
            //    File.AppendAllText(path, $"{students[i]}\t {grade.Next(0,100)}\n");
            //}

            //請設計樂透開獎程式。
            try
            {
                Console.WriteLine("請從1-49的數字選擇6個號碼+1個特別號");
                int[] pickedNum = new int[7];
                int[] lottery = new int[7];
                Random numbers = new Random();
                int holder;
                int count = 0;
                int lotteryIndex =0;
                bool skip = false;
                //玩家輸入自己的號碼
                for (int i = 0; i < 7; i++)
                {
                    if (i != 6)
                    {
                        Console.WriteLine("請輸入一般號:");
                    }
                    else
                    {
                        Console.WriteLine("請輸入特別號:");
                    }

                    holder = Convert.ToInt32(Console.ReadLine());
                    if (holder < 1 || holder > 49 || pickedNum.Contains(holder))
                    {
                        Console.WriteLine("請重新來過");
                        skip = true;
                        break;
                    }
                    pickedNum[i] = holder;

                }
                //樂透彩開獎
                do {
                    int lotteryNum =  numbers.Next(1, 50);
                    //不要重複
                    if (lottery.Contains(lotteryNum))
                    {
                        lotteryIndex = 0;
                    } else

                    {
                        if (lotteryIndex >= 7)
                        {
                            break;
                        }
                        lottery[lotteryIndex] = lotteryNum;
                    }   
                    lotteryIndex++;

                } while (true);

                if (!skip)
                {
                    foreach (int num in lottery)
                    {
                        foreach (int n in pickedNum)
                        {
                            if (n == num)
                            {
                                count++;
                            }
                        }
                    }

                    if (count < 6 && count >= 3)
                    {
                        Console.WriteLine("恭喜你中獎了");
                    }
                    else if (count >= 6)
                    {
                        Console.WriteLine("恭喜你中了頭獎!!!");
                    }
                    else
                    {
                        Console.WriteLine("謝謝你繳納國庫");
                    }

                    Console.Write("開獎號碼為: ");

                    foreach (int n in lottery)
                    {
                        Console.Write($"{n} ");
                    }
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("請從1-49的數字選擇6個號碼+1個特別號");
            }

            //請在文字檔裡輸入所有午餐的店家，
            //讀取文字檔，隨機抽出今天中午要吃哪一家。
            //path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\Lunch.txt";
            //string[] lunchList = File.ReadAllLines(path, Encoding.UTF8);
            //Random randomInt = new Random();
            //int choice =  randomInt.Next(0, lunchList.Length);
            //Console.WriteLine(lunchList[choice]);


            //請在文字檔裡輸入所有教室裡的學員名字，
            //讀取文字檔，隨機抽出今天的值日生，抽過不能再被抽中，
            //直到全部學員都被抽過，才可以再被抽。

            //string path = @"C:\Users\zemmy\OneDrive\桌面\六角\火箭隊\第三周\backend\BackendHomework\BackendHomework\files\dutyPerson.txt";
            //string[] duty = File.ReadAllLines(path, Encoding.GetEncoding("big5"));
            //Random randomInt = new Random();
            //int len = duty.Length;
            //bool filled = false;
            //int count = 0;
            //do
            //{
            //    int rom = randomInt.Next(0, len);
            //    if (duty[rom] == null)
            //    {
            //        continue;
            //    }
            //    Console.WriteLine($"{duty[rom]}今天是值日生");
            //    duty[rom] = null;
            //    count++;
            //    if (count == len)
            //    {
            //        filled = true;
            //    }
            //} while (!filled);
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
            Console.ReadKey();
        }
    }
}
