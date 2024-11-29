using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //習題一 //寫一程式，輸入a,b,c,d，計算((𝑎+𝑏))/((𝑐−𝑑))×2。
            //double a, b, c, d, z;
            //Console.WriteLine("請輸入數字");
            //Console.Write("a = ");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("b = ");
            //b = Convert.ToInt32(Console.ReadLine());
            //Console.Write("c = ");
            //c = Convert.ToInt32(Console.ReadLine());
            //Console.Write("d = ");
            //d = Convert.ToInt32(Console.ReadLine());
            //if (c - d == 0)
            //{
            //    Console.WriteLine("c-d的值為0，無法做除法");
            //}
            //else
            //{
            //    z = ((a + b) / (c - d)) * 2;
            //    Console.WriteLine(z);
            //}

            //Console.WriteLine("按任一鍵繼續");
            //Console.ReadKey();
            //-------------------------------------------------------------------------------------

            //寫一程式，輸入一組二元一次方程式之係數，輸出方程式的解。
            //int x, y;
            //Console.WriteLine("請輸入數字");
            //Console.Write("a1 = ");
            //int a1 = Convert.ToInt32( Console.ReadLine());
            //Console.Write("a2 = ");
            //int a2 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("b1 = ");
            //int b1 = Convert.ToInt32( Console.ReadLine());
            //Console.Write("b2 = ");
            //int b2 = Convert.ToInt32( Console.ReadLine());
            //Console.Write("c1 = ");
            //int c1 = Convert.ToInt32( Console.ReadLine());
            //Console.Write("c2 = ");
            //int c2 = Convert.ToInt32( Console.ReadLine());
            //x = (c1 * b2 - c2 * b1)/(a1*b2-a2*b1);
            //y = (c1 * a2 - c2 * a1) / (b1 * a2 - a1 * b2);
            //Console.WriteLine($"{x} {y}");
            //Console.WriteLine("按任一鍵繼續");
            //Console.ReadKey();
            //-------------------------------------------------------------------------------------

            //1-3. 輸入a和b，求： (提示:使用Math)
            //y=  (𝑎^2+𝑏^2)/(𝑎^2−𝑏^2) 

            //double a, b, y;
            //Console.WriteLine("請輸入數字");
            //Console.Write("a = ");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("b = ");
            //b = Convert.ToInt32(Console.ReadLine());
            //double resultAddition = Math.Pow(a, 2) + Math.Pow(b, 2);
            //double resultSubtraction = Math.Pow(a, 2) - Math.Pow(b, 2);
            //y = resultAddition/ resultSubtraction;
            //Console.WriteLine(y);
            //Console.WriteLine("按任一鍵繼續");
            //Console.ReadKey();
            //-------------------------------------------------------------------------------------

            //1 - 4.輸入a和b，求： (提示: 使用Math)
            //y = √(𝑎^2 +𝑏^2)
            //double a, b, y;
            //Console.Write("a = ");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("b = ");
            //b = Convert.ToInt32(Console.ReadLine());
            //y = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            //Console.WriteLine(y);
            //Console.WriteLine("按任一鍵繼續");
            //Console.ReadKey();
            //-------------------------------------------------------------------------------------
            //1 - 5.輸入a、b和c，求：
            //y = a - (b + c)(3a - c)
            //int y, a,b, c;
            //Console.WriteLine("請輸入數字");
            //Console.Write("a = ");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("b = ");
            //b = Convert.ToInt32(Console.ReadLine());
            //Console.Write("c = ");
            //c = Convert.ToInt32(Console.ReadLine());
            //y = a - ((b + c)*(3*a - c));
            //Console.WriteLine(y);
            //Console.WriteLine("按任一鍵繼續");
            //Console.ReadKey();
            //--------------------------------------------------------------------------------------
            //1 - 6請隨意輸入正負數，取絕對值輸出
            //Console.WriteLine("請輸入任意數字");
            //double num = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{num}絕對值為{Math.Abs(num)}");
            //Console.WriteLine("按任一鍵繼續");
            //Console.ReadKey();

            //--------------------------------------------------------------------------------------
            //1-7輸入的西元年份轉換成民國年份後輸出
            //int convertNumber = 1911;
            //Console.WriteLine("請輸入西元年分");
            //int year = Convert.ToInt32(Console.ReadLine());
            //int yearROC = year - convertNumber;
            //Console.WriteLine($"西元{year}年是民國{yearROC}年");
            //Console.WriteLine("按任一鍵繼續");

            //Console.ReadKey();
            //---------------------------------------------------------------------------
            //1 - 8請輸入身高體重，輸出BMI
            double height, weight, BMI;
            //體重÷身高(公尺)的平方
            Console.WriteLine("請輸入身高");
            // 將輸入的身高從公分轉換為公尺
            height = Convert.ToDouble(Console.ReadLine()) / 100;
            Console.WriteLine("請輸入體重");
            weight = Convert.ToDouble(Console.ReadLine());
            BMI = Math.Round(weight / Math.Pow(height, 2), 2);
            Console.WriteLine($"BMI值為{BMI}");
            Console.WriteLine("按任一鍵繼續");
            Console.ReadKey();
        }
    }
}
