using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZI
{
    class RLECoder
    {
        public string Encode(string input)
        {
            string subResult = input + "";
            string result = "";
            while (subResult.Length>0)
            {
                string tempResult = Minimizer(subResult);
                string temp;
                subResult = TrimFirst(subResult, tempResult,out temp);
                if (result.EndsWith(temp))
                {
                    break;
                }
                result += temp;
            }
            return result;
        }
        public string Decode(string input)
        {
            input = input.ToLower();
            
            StringBuilder builder = new StringBuilder();
            string subResult = input + "";

            while (subResult.Length > 0)
            {
                int i = 0;
                for (; subResult[i] < 48 || subResult[i] > 57; i++) ;
                int k = i;
                string sq = "";
                for (; i < subResult.Length && subResult[i] > 47 && subResult[i] < 58; i++)
                {
                    sq += subResult[i];
                }
                for(int j = int.Parse(sq);j>0;j--)
                    builder.Append(subResult.Substring(0, k));
                subResult = subResult.Substring(i);
            }

            return builder.ToString();
        }


        public string Minimizer(string str)
        {
            StringBuilder[] builder = new StringBuilder[str.Length];
            for (int k = 0; k < str.Length; k++)
            {
                builder[k] = new StringBuilder();
                for (int i = 0; i < str.Length;)
                {
                    string pattern;
                    string searchSubstring;
                    if ((i + k + 1) > str.Length)
                    {
                        pattern = str.Substring(i, str.Length - i);
                    }
                    else
                    {
                        pattern = str.Substring(i, k + 1);
                    }
                    if ((i + k + 1) >= str.Length)
                        searchSubstring = str.Substring(i, str.Length - i);
                    else
                    {
                        if ((i + 2 * k + 2) >= str.Length)
                            searchSubstring = str.Substring(i + k + 1, str.Length - i - k - 1);
                        else
                            searchSubstring = str.Substring(i + k + 1, k + 1);
                    }
                    int counter = 1;



                    while (IsNextEquals(searchSubstring, pattern))
                    {
                        i += k + 1;
                        if (i >= str.Length)
                            break;
                        counter++;
                        if ((i + k + 1) >= str.Length)
                            searchSubstring = str.Substring(i, str.Length - i);
                        else
                        {
                            if ((i + 2 * k + 2) >= str.Length)
                                searchSubstring = str.Substring(i + k + 1, str.Length - i - k - 1);
                            else
                                searchSubstring = str.Substring(i + k + 1, k + 1);
                        }
                    }
                    i += k + 1;
                    builder[k].Append(pattern);
                    builder[k].Append(counter);

                }
            }
            return FindMinBuilder(builder);
        }

        private string TrimFirst(string str,string pattern, out string cutedPart)
        {
            int i = 0;
            for (; pattern[i] < 48 || pattern[i] > 57; i++) ;
            int k = i;
            string sq = "";
            for (; i<pattern.Length && pattern[i] > 47 && pattern[i] < 58; i++)
            {
                sq += pattern[i];
            }
            cutedPart = pattern.Substring(0, i);
            return str.Substring(int.Parse(sq)*k);
        }

        private bool IsNextEquals(string input, string pattern)
        {
            if (!input.Equals(pattern))
                return false;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (input[i] != pattern[i])
                    return false;
            }
            return true;
        }

        private string FindMinBuilder(StringBuilder[] builders)
        {
            string minStr = builders[0].ToString();
            int minFirstPatternSize = int.MaxValue;
            int maxFirstPatternCount = int.MinValue;
            for (int i = 0; i < builders.Length; i++)
            {
                int k = 0;
                for (; builders[i].ToString()[k] < 48 || builders[i].ToString()[k] > 57; k++) ;
                int localPatternSize = k;
                
                string sq = "";
                for (; k < builders[i].Length && builders[i].ToString()[k] > 47 && builders[i].ToString()[k] < 58; k++)
                {
                    sq += builders[i].ToString()[k];
                }
                int localPatternCount = int.Parse(sq);
                if (localPatternCount > maxFirstPatternCount)
                {
                    maxFirstPatternCount = localPatternCount;
                    minStr = builders[i].ToString();
                    if (minFirstPatternSize == int.MaxValue)
                        minFirstPatternSize = localPatternSize;
                }else if (localPatternSize < minFirstPatternSize)
                {
                    minFirstPatternSize = localPatternSize;
                    minStr = builders[i].ToString();
                    if (maxFirstPatternCount == int.MinValue)
                        maxFirstPatternCount = localPatternCount;
                }
            }
            return minStr;
        }
    }
}
