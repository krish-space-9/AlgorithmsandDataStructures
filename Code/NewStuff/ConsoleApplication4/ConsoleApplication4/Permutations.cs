using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Permutations
    {
        public IList<string> GetPermutations(string s)
        {
            IList<string> res = new List<string>();
            GetPermutationsHelper(s.ToCharArray(), 0, res);
            return res;
        }

        private void GetPermutationsHelper(char[] c,int index, IList<string> res)
        {
            if(index==c.Length)
            {
                res.Add(new string(c));
                return;
            }

            for(int i = index;i<c.Length;i++)
            {
                if(index!=i)
                {
                    swap(c, i, index);
                }
                GetPermutationsHelper(c, index + 1, res);
                if(index!=i)
                {
                    swap(c, i, index);
                }
            }
        }

        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

    }
}
