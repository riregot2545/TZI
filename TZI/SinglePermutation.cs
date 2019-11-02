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


    }
}
