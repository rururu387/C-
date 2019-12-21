using System;
using System.Runtime.InteropServices;

namespace Goose3.NET
{
    class Program
    {
        [DllImport(@"MyDllSecond.dll", EntryPoint = "mainCpp", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern long mainCpp(double[] matrixArr, int size, double[] rVal, int rValSize);
        static long c_Block(MatrixC_ myMatrixC_, double[] myArr)
        {
            double[] myArr2 = { };
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();
            try
            {
                myArr2 = myMatrixC_.solveSystem(myArr);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            SW.Stop();
            string str = "Solution:\t";
            for (int i = 0; i < myArr2.Length; i++)
            {
                str += Math.Round(myArr2[i], 3).ToString() + '\t';
            }
            if (myArr2.Length != 0)
                Console.WriteLine(str);
            Console.WriteLine("Calculations lasted for " + SW.ElapsedMilliseconds + " milliseconds");
            return SW.ElapsedMilliseconds;
        }
        static long cppBlock(MatrixC_ myMatrixCpp, double[] myArr)
        {
            double[] matrixArr = new double[myMatrixCpp.size * myMatrixCpp.size];

            for (int i = 0; i < myMatrixCpp.size; i++)
            {
                for (int j = 0; j < myMatrixCpp.size; j++)
                {
                    matrixArr[i * myMatrixCpp.size + j] = myMatrixCpp.getMatrix()[i][j];
                }
            }
            Console.WriteLine();
            long timeCpp = mainCpp(matrixArr, myMatrixCpp.size, myArr, myArr.Length);
            return timeCpp;
        }
        static void menu()
        {
            int action = 0;
            correctInput input = new correctInput();
            TimeList tList = new TimeList();
            do
            {
                Console.WriteLine("Input action. 0 - quit, 1 - create matrix and solve it, 2 - print data, 3 - serealize data, 4 - deserealize data:");
                action = input.getInt();
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Size of matrix to solve: ");
                        int amount = input.getInt();
                        MatrixC_ myMatrix = new MatrixC_(amount);

                        Random rnd = new Random();
                        double[] myArr = new double[amount];
                        for (int i = 0; i < amount; i++)
                        {
                            myArr[i] = rnd.Next(0, 10000);
                        }
                        long millisecondsC_ = c_Block(myMatrix, myArr);
                        long millisecondsCpp = cppBlock(myMatrix, myArr);
                        TimeItem item;
                        if (Convert.ToDouble(millisecondsCpp) == 0)
                        {
                            item = new TimeItem(millisecondsC_, millisecondsCpp, -100);
                        }
                        else
                            item = new TimeItem(millisecondsC_, millisecondsCpp, Convert.ToDouble(millisecondsC_) / Convert.ToDouble(millisecondsCpp));
                        tList.add(item);
                        break;
                    case 2:
                        Console.WriteLine(tList.ToString());
                        break;
                    case 0:
                    case 3:
                        Console.WriteLine("Input name of file to serealize to:");
                        string fileout = Console.ReadLine();
                        tList.save(fileout);
                        break;
                    case 4:
                        Console.WriteLine("Input name of file to deserealize from:");
                        string filein = Console.ReadLine();
                        tList.load(filein);
                        break;
                    default:
                        Console.WriteLine("Goose");
                        break;
                }
            } while (action != 0);
        }
        static void Main(string[] args)
        {
            menu();            
        }
    }
}
