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
            int rowSize = 2;
            int colSize = 5;
            int[,] Test = new int[rowSize, colSize];
            int[] flatten = new int[colSize];

            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    Console.Write($"請輸入第{i + 1}行第{j + 1}個數字");
                    Test[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i<colSize; i++)
            {
                for (int j = 0; j <rowSize; j++)
                {
                    flatten[i] += Test[j,i];
                }
            }

            foreach(int i in flatten)
            {
                Console.WriteLine(i);
            }


            Console.ReadKey();

        }
    }
}
