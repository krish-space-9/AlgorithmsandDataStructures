using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "it is a great day in seattle";
            List<string> allRes = new List<string>();
            for (int i =1;i<= 3;i++)
            {

                allRes.AddRange(GetNgrams(a, i));
            }
            
            
           // var res = GetNgrams(a, 2);
        }

        static IList<string> GetNgrams(string s, int n)
        {
            string[] tokens = s.Split(' ');
            IList<string> ngramResults = new List<string>();

            int offset = tokens.Length - n + 1;
            for(int i =0;i< offset;i++)
            {
                ngramResults.Add(BuildString(tokens, i, i + n));
            }

            return ngramResults;
            

        }


        static string BuildString(string[] tokens, int start, int end)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = start;i<end;i++)
            {
                if(tokens[i]!=" ")
                {
                    sb.Append(tokens[i]+ " ");
                }
               
            }
            return sb.ToString();
        }
    }
}
