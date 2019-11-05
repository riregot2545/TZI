using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZI
{
    class SinglePermutation
    {
        private int[] key = null;

        public void setKey(int[] _key)
        {
            key = new int[_key.Length];
            for(int i = 0; i < _key.Length; i++)
            {
                key[i] = _key[i];
            }
        }

        public void setKey(string[] _key)
        {
            key = new int[_key.Length];
            for(int i = 0; i< _key.Length; i++)
            {
                key[i] = Convert.ToInt32(_key[i]);
            }
        }

        public void setKey(string _key)
        {
            setKey(_key.Split(' '));
        }

        public string Encrypt(string input)
        {
            for (int i = 0; i < input.Length % key.Length; i++)
                input += "Я";
            if (key.Length > input.Length)
                Array.Resize(ref key, input.Length);
            string res = "";
            for(int i = 0; i < input.Length; i += key.Length)
            {
                char[] permutation = new char[key.Length];
                for (int j = 0; j < key.Length; j++)
                    permutation[key[j] - 1] = input[i + j];
                for (int j = 0; j < key.Length; j++)
                    res += permutation[j];
            }
            return res;
        }

        public string Decrypt(string input)
        {
            string res = "";
            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] permutation = new char[key.Length];
                for (int j = 0; j < key.Length; j++)
                    permutation[j] = input[i + key[j] - 1];
                for (int j = 0; j < key.Length; j++)
                    res += permutation[j];
            }
            return res;
        }
    }
}
