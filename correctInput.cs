using System;
using System.Collections.Generic;
using System.Text;

namespace Goose3.NET
{
    class correctInput
    {
        public int getInt()
        {
            bool myFlag = true;
            int num = 0;
            do
            {
                string str = Console.ReadLine();
                for (int i = 0; i < str.Length; i++)
                {
                    if (!Char.IsDigit(str[i]))
                    {
                        Console.WriteLine("Invalid int number. Retry:");
                        myFlag = false;
                        break;
                    }
                    num = num * 10 + str[i] - '0';
                }
            } while (!myFlag);
            return num;
        }
        public double getDouble()
        {
            int myFlag = 1;
            double whole = 0, rational = 0;
            int cnt = 0;
            do
            {
                string str = Console.ReadLine();
                for (int i = 0; i < str.Length; i++)
                {
                    if (!Char.IsDigit(str[i]) && str[i] != '.')
                    {
                        Console.WriteLine("Invalid double number. Retry:");
                        myFlag = 0;
                        break;
                    }
                    else if (str[i] == '.')
                    {
                        myFlag = 2;
                    }
                    else if (myFlag == 1)
                    {
                        whole = whole * 10 + str[i] - '0';
                    }
                    else if (myFlag == 2)
                    {
                        cnt++;
                        rational = rational * 10 + str[i] - '0';
                    }
                }
            } while (myFlag == 0);
            return whole + rational / Math.Pow(10, cnt);
        }
    }
}
