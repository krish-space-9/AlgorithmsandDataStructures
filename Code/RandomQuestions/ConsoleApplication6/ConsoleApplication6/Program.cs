using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            bool b = s.IsValidSerialization(@"9,3,4,#,#,1,#,#,2,#,6,#,#,#");
            Console.WriteLine(b);
            Console.ReadLine();

        }
    }

    public class Solution
    {
        public bool IsValidSerialization(string preorder)
        {
            if (preorder == null) return false;
            if (preorder.Length == 0) return false;
            string[] tokens = preorder.Split(',');
            int count = 0, specialCount = 0;

            bool result = false;
            while(count<tokens.Length)
            {
                result = IsValidHelper(tokens, ref count, tokens.Length, ref specialCount);
                if (result == false) return false;
            }
            return result;
        }

        private bool IsValidHelper(string[] tokens, ref int count, int n, ref int specialCount)
        {
            if (count >= n)
            {
                return false;
            }
            if (tokens[count] == "#")
            {
                if (count == 0 || specialCount == 2) return false;
                specialCount++;
                count++;
                return true;
            }


            if (specialCount > 0)
            {
                specialCount = 0;
            }
            count++;

            bool l = IsValidHelper(tokens, ref count, n, ref specialCount);
            if (!l) return false;

            bool r = IsValidHelper(tokens, ref count, n, ref specialCount);
            if (!r) return false;

            return true;

        }
    }
}
