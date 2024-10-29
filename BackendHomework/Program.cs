using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //例題5.1-利用一維陣列求10個數字的計算平均值。

            //int[] A = new int[10];
            //int average = 0;

            //for (int i = 0, n=A.Length; i<n ; i++)
            //{
            //    Console.WriteLine($"輸入第{i+1}個數字:");
            //    A[i] = Convert.ToInt32(Console.ReadLine());

            //}

            //Console.Write("平均值為:");

            //for (int i = 0, n = A.Length; i < n; i++)
            //{
            //    average += A[i];
            //}
            //Console.WriteLine(average/A.Length);
            //Console.WriteLine(A.Aggregate(0, (accu, a) =>  accu + a )/A.Length);
            //Console.WriteLine(A.Average());

            //例題5.2-利用一維陣列求10個數字的最大值。

            //int[] A = new int [10];
            //int maxValue = int.MinValue;
            //for (int i = 0, n = A.Length; i < n; i++)
            //{
            //    Console.Write($"請輸入第{i+1}個數字:");
            //    A[i] = Convert.ToInt32(Console.ReadLine());
            //    if (A[i] > maxValue)
            //    {
            //        maxValue = A[i];
            //    }
            //}

            //Console.WriteLine($"最大值為{maxValue}");

            //例題5.3-搜尋問題：輸入10個數字至A[ ]，再輸入x，判斷x是否存在於A陣列中
            //如果存在，輸出所在的註標(索引)值，若不存在，則告知不存在。

            //int[] A = new int[10];
            //for (int i = 0, n = A.Length; i < n; i++)
            //{
            //    Console.Write("請輸入10個值:");
            //    Console.Write($"請輸入index{i}的值:");
            //    A[i] = Convert.ToInt32(Console.ReadLine());

            //}

            //Console.Write("請輸入x:");
            //int x = Convert.ToInt32(Console.ReadLine());
            //int count = 0;

            //for (int i = 0, n = A.Length; i < n; i++)
            //{
            //    if (A[i] == x)
            //    {
            //        Console.WriteLine($"找到x，位於index{i}");
            //        count++;
            //    }

            //}

            //if (count == 0)
            //{
            //    Console.WriteLine("x這個數字不存在此陣列");

            //}

            //例題5.4求兩個2乘3的二維矩陣相加之結果，第一個及第二個矩陣分別以A及B表示
            //相加之結果存入C矩陣，最後將C矩陣內容顯示出來。

            //int[,] A = new int[2, 3];
            //int[,] B = new int[2, 3];
            //int[,] C = new int[2, 3];
            //for (int i = 0, n = A.GetLength(0); i < n;i++)
            //{
            //    for (int j = 0, m = A.GetLength(1); j < m; j++)
            //    {
            //        Console.WriteLine($"請輸入A第{i + 1}行，第{j + 1}個數:");
            //        A[i,j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //for (int i = 0, n = B.GetLength(0); i < n; i++)
            //{
            //    for (int j = 0, m = B.GetLength(1); j < m; j++)
            //    {
            //        Console.WriteLine($"請輸入B第{i + 1}行，第{j + 1}個數:");
            //        B[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //for (int i = 0, n = C.GetLength(0); i < n; i++)
            //{
            //    for (int j = 0, m = C.GetLength(1); j < m; j++)
            //    {
            //        C[i, j] = A[i, j] + B[i, j];
            //    }
            //}

            //Console.WriteLine("C陣列為:");

            //for (int i = 0, n =C.GetLength(0); i < n; i++)
            //{
            //    for (int j = 0, m =C.GetLength(1); j < m; j++){
            //        Console.Write($"{C[i, j]}\t");
            //}
            //    Console.WriteLine();
            //}

            //例題5.5-求2乘3的A矩陣乘以3乘1的B矩陣，結果存入2乘1的C矩陣，最後將C矩陣的內容顯示出來。


            int[,] A = new int [2, 3];
            int[,] B = new int [3, 1];
            int[,] C = new int [2, 1];
            for (int i =0, n = A.GetLength(0); i < n; i++)
            {
                for (int j = 0, m = A.GetLength(1); j < m; j++)
                {
                    Console.WriteLine("輸入A矩陣");
                    Console.Write($"請輸入{i+1}行第{j+1}列的數字:");
                    A[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }


            for (int i = 0, n = B.GetLength(0); i < n; i++)
            {
                for (int j = 0, m = B.GetLength(1); j < m; j++)
                {
                    Console.WriteLine("輸入B矩陣");
                    Console.Write($"請輸入{i + 1}行第{j + 1}列的數字:");
                    B[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //目前想不出來怎麼把矩陣給放到迴圈相加
            C[0, 0] = A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0] + A[0, 2] * B[2, 0];
            C[1,0] = A[1, 0]* B[0, 0] + A[1,1] * B[1, 0] + A[1,2] * B[2,0];


            for (int i = 0, n = C.GetLength(0); i < n; i++)
            {
                for (int j = 0, m = C.GetLength(1); j < m; j++)
                {
                    Console.WriteLine("C陣列為9");
                    Console.Write($"{C[i, j]}\t");
                }
                Console.WriteLine();
            }



            //5-1寫一程式，將10個數字讀入A陣列，然後逐一檢查此陣列，如A[i]>5，則令A[i]=A[i]-5，否則A[i]=A[i]+5
            //int[] A = new  int [10];
            //for (int i =0, n=A.Length; i <n; i++)
            //{
            //    Console.WriteLine($"請輸入第{i+1}個數字");
            //    A[i] = Convert.ToInt32(Console.ReadLine());
            //    if (A[i] > 5)
            //    {
            //        A[i]-=5;
            //    }
            //}
            //foreach(int i in A)
            //{
            //    Console.WriteLine(i);
            //}

            //5-2.寫一程式，將10個數字讀入A陣列，對每一個數字，令A[i]=A[i]+i。
            //int size = 10;
            //int[] A = new int[size];
            //for (int i = 0; i < size; i++) { 
            //Console.WriteLine($"輸入第{i+1}個數字: ");
            //    A[i] = Convert.ToInt32(Console.ReadLine())+i;
            //    Console.WriteLine($"第{i + 1}個數字為{A[i]}");
            //}

            //5-3.寫一程式，將10個數字讀入A陣列，並建立一個B陣列，如A[i]≥0，令B[i]=1，否則令B[i]=0。
            //int size = 10;
            //int[] A = new int[size], B = new int[size];
            //for (int i =0; i < size; i++)
            //{
            //    Console.Write($"輸入陣列A第{i + 1}個數字:");
            //    A[i] = Convert.ToInt32(Console.ReadLine());
            //    if (A[i] >= 0)
            //    {
            //        B[i] = 1;
            //    }
            //    else
            //    {
            //        B[i] = 0;
            //    }

            //    Console.WriteLine($"陣列A第{i+1}個數字為{A[i]}。陣列B第{i + 1}個數字為{B[i]}");
            //}

            //5-4.寫一程式，將15數字存入3×5的二維陣列A中，求每一行及每一列數字的和。
            //int row = 3, col = 5;
            //int[,] A = new int[row, col];
            //[[x, x, x, x, x],[x, x, x, x, x],[x, x, x, x, x]];
            //行
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        Console.WriteLine($"請輸入第{i + 1}行，第{j + 1}個數字");
            //        A[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //for (int i = 0, n = A.GetLength(0); i < n; i++)
            //{
            //    int rowSum = 0;

            //    for (int j = 0, m = A.GetLength(1); j < m; j++)
            //    {
            //        rowSum += A[i, j];
            //    }
            //    Console.WriteLine($"第{i}行的總數為{rowSum}");
            //}
            //for (int i = 0; i < col; i++)
            //{
            //    for (int j = 0; j < row; j++)
            //    {
            //        Console.WriteLine($"請輸入第{i + 1}列，第{j + 1}個數字");
            //        A[j, i] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            ////列

            //for (int i = 0, n = A.GetLength(1); i < n; i++)
            //{
            //    int colSum = 0;

            //    for (int j = 0, m = A.GetLength(0); j < m; j++)
            //    {
            //        colSum += A[j, i];
            //    }
            //    Console.WriteLine($"第{i+1}列的總數為{colSum}");
            //}

            //5-5.寫一程式，將15數字存入3×5的二維陣列A中，求每一行及每一列數字的最小值。
            //int rowSize = 3, colSize = 5;
            //int[,] A = new int[rowSize, colSize];
            //int[] rowSum = new int[rowSize];
            //int[] colSum = new int[colSize];
            //int minRow = int.MaxValue;
            //int minCol = int.MaxValue;
            //for (int i = 0; i<rowSize; i++)
            //{
            //    for (int j = 0; j <colSize; j++)
            //    {
            //        Console.Write($"請輸入第{i + 1}行，第{j + 1}個數字:");
            //        A[i, j] = Convert.ToInt32(Console.ReadLine());
            //        rowSum[i] += A[i, j];
            //        colSum[j] += A[i, j];   
            //    }

            //}            
            //for (int i =0; i < rowSum.Length; i++)
            //{
            //    if (rowSum[i] < minRow){
            //        minRow = rowSum[i];
            //    }
            //}

            //for (int i = 0; i < colSum.Length; i++)
            //{
            //    if (colSum[i] < minCol)
            //    {
            //        minCol = colSum[i];
            //    }
            //}          
            //for (int i = 0; i < rowSum.Length;i++)
            //{
            //    Console.WriteLine($"第{i + 1}行的總數{rowSum[i]}");
            //}

            //for (int i = 0; i < colSum.Length; i++)
            //{
            //    Console.WriteLine($"第{i + 1}列的總數{colSum[i]}");
            //}
            //Console.WriteLine($"每行最小值為{minRow}，每列最小值為{minCol}");

            //5-6.寫一程式，輸入兩組數字：a1,a2,…,a5和b1,b2,…,b5。求ai+bi，i=1到i=5。
            //int rowSize = 2;
            //int colSize = 5;
            //int[,] Test = new int[rowSize, colSize];
            //int[] flatten = new int[colSize];

            //for (int i = 0; i < rowSize; i++)
            //{
            //    for (int j = 0; j < colSize; j++)
            //    {
            //        Console.Write($"請輸入第{i + 1}行第{j + 1}個數字");
            //        Test[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i<colSize; i++)
            //{
            //    for (int j = 0; j <rowSize; j++)
            //    {
            //        flatten[i] += Test[j,i];
            //    }
            //}

            //foreach(int i in flatten)
            //{
            //    Console.WriteLine(i);
            //}


            //5-7.寫一程式，輸入兩組數字： a1,a2,…,a5和b1,b2,…,b5。令x為a中的最大值，令y為b中的最大值，求x與y中較小者。
            //int[] A = new int [5];
            //int[] B = new int [5];
            //int x=int.MinValue, y =int.MinValue;
            //for (int i = 0; i < A.Length; i++) { 
            //    Console.WriteLine($"輸入A{i}:");
            //    A[i] = Convert.ToInt32(Console.ReadLine());
            //    if (A[i] > x) { 
            //        x = A[i];
            //    }
            //    Console.WriteLine($"輸入B{i}:");
            //    B[i] = Convert.ToInt32(Console.ReadLine());
            //    if (A[i] > y)
            //    {
            //        y = B[i];
            //    }
            //}

            //string result = (x > y )?$"x最大值為{x}，y最大值為{y}，x比較大" :$"x最大值為{x}，y最大值為{y}，y比較大";


            //Console.WriteLine(result);


            Console.ReadKey();

        }
    }
}
