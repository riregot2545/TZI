using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZI
{
    class LunSimple
    {
        private int sum;

        public int Sum { get => sum; set => sum = value; }

        public bool Check(string inputStr)
        {
            int[] input = StrToIntArray(inputStr);
            int[] sum = new int[input.Length];

            int i = 0;
            if (input.Length % 2 == 0)
            {
                if (input[i] * 2 > 9)
                    sum[i] = input[i] * 2 - 9;
                else
                    sum[i] = input[i] * 2;
                i++;
            }
            for (; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (input[i] * 2 > 9)
                        sum[i] = input[i] * 2 - 9;
                    else
                        sum[i] = input[i] * 2;
                }
                else
                    sum[i] = input[i];
            }
            Sum = sum.Sum();
            return Sum % 10 == 0;
        }
        private int[] StrToIntArray(string str)
        {
            char[] charArray = str.ToCharArray();
            int[] result = new int[charArray.Length];
            int realLenght = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (charArray[i] != 32)
                {
                    result[realLenght] = charArray[i] - 48;
                    realLenght++;
                }
            }
            Array.Copy(result, result=new int[realLenght], realLenght);
            return result;
        }
    }
}
