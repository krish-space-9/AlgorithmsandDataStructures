using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Relation> list = new List<Relation>();
            list.Add(new Relation(15, 20, true));
            list.Add(new Relation(19, 80, true));
            list.Add(new Relation(17, 20, false));
            list.Add(new Relation(16, 80, false));
            list.Add(new Relation(80, 50, false));
            list.Add(new Relation(50, -1, false));
            list.Add(new Relation(20, 50, true));

            BinaryTree tree = new BinaryTree();
            // tree.BuildBinaryTree(list);


            string[] inputs = { "aghkafgkit", "dfghako", "qwemnaarkf" };
            //int c = CountCommonCharacters(inputs);


            int[] a = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int start = -1;
            int end = -1;
            //int sum = MaxContigiousSum(a, ref start, ref end);
            //Console.WriteLine($"Max sum is {sum} with start = {start} and end = {end}");

            //int[] b = { -1, -3, -10, -1, -5, 8, 9, -2, 0, 20000 };
            //int[] b = { 6, -3, -10, 0, 2 };
            int[] b = { 1, -2, -3, 0, 7, -8, -2 };
            //int prod = MaxContigiousProduct(b, ref start, ref end);
            //Console.WriteLine($"Max product is {prod} with start = {start} and end = {end}");


            int[] inp = { 1, 2, 3 };
            // GetPermutations(inp);
            GetCombinations(inp);
            //Console.WriteLine(c);
            Console.ReadLine();


        }

        static int CountCommonCharacters(string[] inputs)
        {
            if (inputs == null || inputs.Length < 2) return 0;

            //Select the first string and record unique char
            HashSet<char> hs = new HashSet<char>();
            int[] count = new int[26];
            foreach (char c in inputs[0])
            {
                if (!hs.Contains(c))
                {
                    hs.Add(c);
                    count[c - 'a'] += 1;
                }

            }

            for (int i = 1; i < inputs.Length; i++)
            {
                string input1 = inputs[i];

                foreach (char c in input1)
                {
                    if (hs.Contains(c))
                    {
                        count[c - 'a'] += 1;
                    }
                }
            }

            int unique_count = 0;
            for (int j = 0; j < count.Length; j++)
            {
                if (count[j] == inputs.Length)
                {
                    int actual_char = j + 'a';
                    Console.WriteLine("common character is " + actual_char);
                    unique_count++;
                }
            }

            return unique_count;
        }

        static int MaxContigiousSum(int[] a, ref int start, ref int end)
        {
            if (a == null || a.Length == 0)
            {
                return 0;
            }

            int current_sum = a[0];
            int max_sum = a[0];
            start = 0;
            end = 0;
            int i = 1;
            while (i < a.Length)
            {
                current_sum = current_sum + a[i];
                if (current_sum < a[i])
                {
                    current_sum = a[i];
                    start = i;
                }

                if (max_sum < current_sum)
                {
                    max_sum = current_sum;
                    end = i;
                }

                i++;
            }
            return max_sum;
        }

        static int MaxContigiousProduct(int[] a, ref int start, ref int end)
        {
            if (a == null || a.Length == 0) return 0;

            int current_prod = a[0];
            int maximum_product = a[0];
            int overall_product = a[0];

            start = end = 0;
            int start1 = -1, end1 = -1;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == 0)
                {
                    current_prod = 1;
                    overall_product = 1;

                }
                else
                {
                    current_prod *= a[i];
                    overall_product = overall_product * a[i];


                    if (current_prod < a[i])
                    {
                        current_prod = a[i];

                        if (start == -1)
                        {
                            start = i;
                        }
                        else
                        {
                            start1 = i;

                        }
                    }

                    if (maximum_product < current_prod)
                    {
                        maximum_product = current_prod;

                        if (end == -1)
                        {
                            end = i;
                        }
                        else if (end > 0 && start1 == -1)
                        {
                            end = i;
                        }
                        else if (start1 != -1)
                        {
                            end1 = i;
                        }
                    }

                    if (maximum_product < overall_product)
                    {
                        maximum_product = overall_product;

                        if (start1 != -1 && end1 != -1)
                        {
                            end = i;

                            // The original sequence itself contains the max prod
                            // So discard the newly started start and end
                            start1 = -1;
                            end1 = -1;
                        }
                    }
                }
            }
            return maximum_product;
        }

        //static int MaxContigiousProduct(int[] a, ref int start, ref int end)
        //{
        //    if (a == null || a.Length == 0) return 0;

        //   int max_product_ending_here = 1;
        //   int max_product_so_far = 1;
        //   int min_product_ending_here = 1;

        //    start = end = 0;
        //    int start1 = -1, end1 = -1;

        //    for (int i = 0; i < a.Length; i++)
        //    {

        //        if(a[i]>0)
        //        {
        //            max_product_ending_here = max_product_ending_here * a[i];

        //        }



        //    }
        //    return maximum_product;
        //}

        static void GetPermutations(int[] a)
        {
            if (a == null || a.Length == 0) return;
            if (a.Length == 1)
            {
                Console.WriteLine(a[0]);
                return;
            }

            int[] result = new int[a.Length];
            bool[] visited = new bool[a.Length];
            int recurLength = 0;
            GetPermutationsHelper(a, result, visited, recurLength);
        }

        public static void GetCombinations(int[] a)
        {

            if (a == null || a.Length == 0) return;
            if (a.Length == 1)
            {
                Console.WriteLine(a[0]);
                return;
            }

            int[] result = new int[a.Length];
            
            //int recurLength = 0;
            GetCombinations(a, result,0,0);

        }
        private static void GetPermutationsHelper(int[] a, int[] result, bool[] visited, int recurLength)
        {
            if (recurLength == a.Length)
            {
                for(int i =0;i< recurLength;i++)
                {
                    Console.Write(result[i] + "  ");
                    
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0
                ; i < a.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    result[recurLength] = a[i];
                    GetPermutationsHelper(a, result, visited, recurLength + 1);
                    visited[i] = false;
                }
            }
        }

        private static void GetCombinations(int[] a, int[] result, int recurLength, int start)
        {

            for(int i = start; i< a.Length;i++)
            {
                result[recurLength] = a[i];
                for(int j = 0; j<=recurLength;j++)
                {
                    Console.Write(result[j]);
                }
                Console.WriteLine();

                if(i<a.Length-1)
                {
                    GetCombinations(a, result, recurLength + 1, start + 1);
                }
            }

        }
    }

    public class Node
    {
        public int Key { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int k)
        {
            Key = k;
            Left = null;
            Right = null;
        }
    }

    public class Relation
    {
        public int Child { get; set; }
        public int Parent { get; set; }
        public bool IsLeftChild { get; set; }
        public Relation(int c, int p, bool isLeft)
        {
            Child = c;
            Parent = p;
            IsLeftChild = isLeft;
        }
    }
}
