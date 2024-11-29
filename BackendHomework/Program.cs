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
            //用字母大小寫來模擬波浪舞的動作後輸出，比如輸入FiFa，輸出FifafIfafiFafifA
            //1.輸入姓名，輸出 Hi~輸入的姓名，比如說輸入Justin，輸出Hi~Justin。
            //Console.Write("請輸入姓名:");
            //string name = Console.ReadLine();
            //Console.WriteLine("Hi~"+name);

            //2.請輸入任何一個字，是否出現在”人人為我，我為人人、饒人不癡漢，癡漢不饒人”這個字串裡。
            //Console.Write("輸入一個字看是否出現在\"人人為我，我為人人、饒人不癡漢，癡漢不饒人\":");
            //string target = Console.ReadLine();
            //string compareSentence = "人人為我，我為人人、饒人不癡漢，癡漢不饒人";
            //bool result = compareSentence.Contains(target);
            //Console.WriteLine(result);

            //3.輸入一段字，輸出每個之間多一個-，如輸入apple ，輸出a-p-p-l-e。
            //Console.Write("輸入一段文字，我們會在每個字之間加上-:");
            //string line = Console.ReadLine();
            //Console.Write(String.Join("-",line.ToCharArray()));

            //4.輸入一個檔名輸出副檔名，如輸入apple.jpg，輸出jpg。
            //Console.Write("輸入一個檔名，我們會輸出他的附檔名:");
            //string fileName = Console.ReadLine();
            //string[] fileNames = fileName.Split('.');
            //string result = "." + fileNames[fileNames.Length - 1];
            //Console.WriteLine(result);
            //5 輸入一個大於五個字的單字，若小於五個字輸出長度不夠，若大於五個字，則輸出前三個字。
            //Console.Write("輸入一個字元大於5的單字:");
            //string voc = Console.ReadLine();
            //if (voc.Length < 5)
            //{
            //    Console.WriteLine("長度不夠");
            //}
            //else {

            //    Console.WriteLine(voc.Substring(0,3));
            //}
            //6.輸入一段字，輸出把輸入的一段字裡面的我，改成小明，如輸入我在唱歌，輸出小明在唱歌。Replace()
            //Console.Write("輸出一段文字，我會把我改成小明:");
            //string target = Console.ReadLine();
            //Console.WriteLine(target.Replace("我","小明"));

            //7.輸入一串字，顯示輸入幾個字。
            //Console.Write("請輸入任何文字，我會告訴你輸入幾個字:");
            //string target = Console.ReadLine();
            //Console.WriteLine($"你輸入了{target.Length}個字");

            //補充習題1.
            //連續輸入10組字，若沒輸入過，就顯示沒出現過，若輸入過，就顯示輸入過。
            //Console.WriteLine("隨機輸入十組字，如果有輸入過就會告訴你已經有輸入過:");
            //string[] inputWords = new string[10];
            //int count = 0;
            //while (count <10) {
            //    Console.Write($"請輸入第{count+1}個字");
            //    string target = Console.ReadLine();
            //    foreach (string word in inputWords) {
            //        if (target.Equals(word))
            //        {
            //            Console.WriteLine("你輸入過了");
            //            break;
            //        }
            //    }
            //    inputWords[count] = target;
            //    count++;
            //}

            //補充習題2.
            //string target = "fifa";
            //for (int i =0; i<target.Length; i++)
            //{
            //    for (int j = 0; j < target.Length; j++)
            //    {
            //        if (i == j)
            //        {
            //            Console.Write((char)((int)target[j]-32));
            //        }
            //        else
            //        {
            //            Console.Write(target[j]);
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //補充習題3.
            //輸入時間，顯示幾時幾分，例如輸入11: 30，輸出11點30分。
            //Console.WriteLine("輸入時間ex:11:30，我會輸出中文的格式:");
            //Console.Write("輸入時間:");
            //string time = Console.ReadLine();
            //string result = time.Replace(":","點")+"分";
            //Console.WriteLine(result);

            //補充習題4
            //輸入的字，轉成HTML，例如輸入Justin,Amy,David
            //輸出<ul>
            //< li > Justin<li>
            //< li > Amy<li>
            //< li > David<li>
            //</ ul >
            //Console.WriteLine("用逗點分開字，我會用html>ul>li列出來 :");
            //string input = Console.ReadLine();
            //toHTMLList(input);

            //補充習題5
            //輸入5處數字，用空白隔開，輸出結果。例如：輸入‘11 19 12 25 1 7 12，輸出總和是87
            //Console.WriteLine("輸入5處數字，用空白隔開");

            //string numbers = Console.ReadLine();
            //string[] numList = numbers.Split(' ');
            //int result = 0;
            //foreach(string n in numList)
            //{
            //    result += Convert.ToInt32(n);
            //}

            //Console.WriteLine(result);
            //補充習題6
            //輸入一串文字，倒著輸出，例如輸入：Justin，輸出nitsuJ
            //Console.WriteLine("輸入一串文字，結果會到著輸出");
            //string target = Console.ReadLine();
            //string result = "";
            //for (int i = target.Length; i >0; i--)
            //{
            //    result += target[i-1];
            //}
            //Console.WriteLine(result);

            Console.ReadKey();
        }

        public static void toHTMLList(string input)
        {
            string[] dividedList = input.Split(',');
            string result = "";
            foreach(string x in dividedList)
            {
                result += "<li>" +x+ "</li>\n";
            }

            result = "<ul>\n" + result + "<ul>\n";

            Console.WriteLine(result);
        }
    }
}
