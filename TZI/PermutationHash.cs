using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZI
{
    class PermutationHash
    {
        private int[] key = null;
        private int sizeOfBlock; //в DES размер блока 64 бит, но поскольку в unicode символ в два раза длинее, то увеличим блок тоже в два раза
        
        private string[] Blocks; //сами блоки
        private string[] TestBlocks;
        private int[] hashCodes;

        public void setKey(int[] _key)
        {
            key = new int[_key.Length];
            for (int i = 0; i < _key.Length; i++)
            {
                key[i] = _key[i];
            }
        }

        public void setKey(string[] _key)
        {
            key = new int[_key.Length];
            for (int i = 0; i < _key.Length; i++)
            {
                key[i] = Convert.ToInt32(_key[i]);
            }
        }

        public void setKey(string _key)
        {
            setKey(_key.Split(' '));
        }

        public string[] getBlocks()
        {
            return Blocks;
        }

        public int[] getHashCodes()
        {
            return hashCodes;
        }

        public void Encrypt(ref string input, ref string[] Blocks)
        {
            for (int i = 0; i < input.Length % key.Length; i++)
                input += "Я";
            sizeOfBlock = key.Length;
            Blocks = new string[input.Length / sizeOfBlock];
            int k = 0;
            for (int i = 0; i < Blocks.Length; i++)//i += key.Length)
            {
                char[] permutation = new char[key.Length];
                for (int j = 0; j < key.Length; j++)
                    permutation[key[j] - 1] = input[k + j];
                for (int j = 0; j < key.Length; j++)
                    Blocks[i] += permutation[j];
                k += key.Length;
            }
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

        public void AddText(string input)
        {
            Encrypt(ref input, ref Blocks);
            hashCodes = new int[input.Length / sizeOfBlock];
            for (int i = 0; i < Blocks.Length; i++)
            {
                hashCodes[i] = Blocks[i].GetHashCode();
            }
        }

        public string TestText(string input)
        {
            string result = "";
            Encrypt(ref input, ref TestBlocks);
            for (int i = 0; i < TestBlocks.Length; i++)
            {
                if (hashCodes[i] != TestBlocks[i].GetHashCode())
                    result += Decrypt(TestBlocks[i]) + "; ";
            }
            return result;
        }
    }
}
