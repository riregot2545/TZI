using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZI
{
    class Vishener
    {
        private string alphabetLatin = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private string alphabetCommon = "12345689.,!?\"\'«»— ";
        private string aplhabetRussian = "йцукенгшщзхъфывапролджэячсмитьбюёЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";
        private Dictionary<char, char[]> codeMatrix;

        private string alphabet;

        public void makeMatrix(int alphabetType)
        {
            if (alphabetType == 0)
                alphabet = alphabetLatin;
            else
                alphabet = aplhabetRussian;
            alphabet += alphabetCommon;

            codeMatrix = new Dictionary<char, char[]>();
            char[] charAlphabet = alphabet.ToArray();
            codeMatrix.Add(alphabet[0], charAlphabet);
            for (int i = 1; i < alphabet.Length; i++)
            {
                charAlphabet = cloneAlphabet(charAlphabet);
                char lastElement = charAlphabet[charAlphabet.Length - 1];
                for (int j = 0; j < charAlphabet.Length; j++)
                {
                    char current = charAlphabet[j];
                    charAlphabet[j] = lastElement;
                    lastElement = current;
                }
                codeMatrix.Add(alphabet[i], charAlphabet);
            }
        }
        private char[] cloneAlphabet(char[] array)
        {
            char[] clone = new char[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                clone[i] = array[i];
            }
            return clone;
        }

        private string extendKey(string key,int length)
        {
            string buffer = key;
            while (buffer.Length < length)
                buffer += key;
            return buffer.Substring(0, length);
        }
        public string Encode(string input,string key)
        {
            if (alphabetLatin.Contains(input[0]))
                makeMatrix(0);
            else
                makeMatrix(1);
            if (input.Length > key.Length)
                key = extendKey(key, input.Length);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                builder.Append(
                    codeMatrix[key[i]][alphabet.IndexOf(input[i])]
                    );
            }
            return builder.ToString();
        }
        public string Decode(string input, string key)
        {
            if (input.Length > key.Length)
                key = extendKey(key, input.Length);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char[] codeArray = codeMatrix[key[i]];
                int index =  Array.FindIndex(codeArray,(m)=>m==input[i]);
                builder.Append(
                    alphabet[index]
                    );
            }
            return builder.ToString();
        }
    }
}
