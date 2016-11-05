using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var p = s.UniquePaths(1, 2);
            Console.WriteLine();
        }
    }

    public class Solution
    {
        public int UniquePaths(int m, int n)
        {

            int[,] matrix = new int[m, n];

            int count = 0;
            Helper(matrix, 0, 0, m, n, ref count);
            return count;
        }

        private void Helper(int[,] matrix, int r, int c, int m, int n, ref int count)
        {
            if (r == m - 1 && c == n - 1)
            {
                Console.WriteLine("hey");
                count++;
                return;
            }

            for (int i = r; i < m; i++)
            {
                for (int j = c; j < n; j++)
                {
                    //Go right

                    if (j !=c-1)
                    {
                        Helper(matrix, i, j + 1, m, n, ref count);
                    }

                    if (i!=r-1)
                    {
                        Helper(matrix, i + 1, j, m, n, ref count);
                    }
                    //Go down
                }
            }
        }
    }
}
