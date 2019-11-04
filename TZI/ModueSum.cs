using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZI
{
    class ModueSum
    {
        private static string alphabetLatin = "qwertyuiopasdfghjklzxcvbnm";
        private string alphabetCommon = "12345689.,!?\"\'— ";
       
        private string alphabet;
        public ModueSum()
        {
            alphabet = alphabetLatin;
        }
      
        private string extendKey(string key, int length)
        {
            string buffer = key;
            while (buffer.Length < length)
                buffer += key;
            return buffer.Substring(0, length);
        }

        public static string GenerateKey(int numOfSymbols)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < numOfSymbols; i++)
            {
                builder.Append(alphabetLatin[random.Next(alphabetLatin.Length)]);
            }
            return builder.ToString();
        }

        public string Encode(string input, string key)
        {
            input = input.ToLower();
            key = key.ToLower();
            if (input.Length > key.Length)
                key = extendKey(key, input.Length);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                builder.Append(alphabet[(alphabet.IndexOf(input[i])+ alphabet.IndexOf(key[i]))%26
                    ]
                    );
            }

            return builder.ToString();
        }
        public string Decode(string input, string key)
        {
            input = input.ToLower();
            key = key.ToLower();
            if (input.Length > key.Length)
                key = extendKey(key, input.Length);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                builder.Append(alphabet[(alphabet.IndexOf(input[i]) + 26 - alphabet.IndexOf(key[i])) % 26
                    ]
                    );
            }

            return builder.ToString();
        }
    }
}
