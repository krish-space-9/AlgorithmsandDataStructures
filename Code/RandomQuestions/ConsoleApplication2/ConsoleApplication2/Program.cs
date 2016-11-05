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
            //MovingAverage m = new MovingAverage(3);
            //double res = 0.0;
            //res = m.next(1);
            //res = m.next(10);
            //res = m.next(3);
            //res = m.next(5);

            Solution s = new Solution();
            s.ReverseWords(" ab  c  ");

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string ReverseWords(string s)
        {

            if (s == null || s.Length < 2) return s;
            return ReverseWordsHelper(s);
        }

        private string ReverseWordsHelper(string s)
        {
            char[] a = s.Trim().ToCharArray();

            Reverse(a, 0, a.Length - 1);

            int start = 0;
            int end;
            while (start < a.Length)
            {
                end = start;
                while (end < a.Length && a[end] != ' ')
                {
                    end++;
                }

                if (end == a.Length)
                {
                    Reverse(a, start, end - 1);
                    break;
                }

                else
                {
                    Reverse(a, start, end - 1);
                    start = end + 1;
                }
            }

            return a.ToString();

        }

        private void Reverse(char[] a, int start, int end)
        {
            char temp;
            while (start < end)
            {
                temp = a[start];
                a[start] = a[end];
                a[end] = temp;
                start++;
                end--;
            }
        }
    }

    public class MovingAverage
    {

        public int[] buffer;
        public int start;
        public int end;
        public double Sum;
        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            buffer = new int[size];
            start = -1;
            end = -1;
            Sum = 0;
        }

        public double next(int val)
        {

            double result = 0.0;
            if (IsFull())
            {

                Sum = Sum - buffer[start] + val;
                buffer[start] = val;
                end = start;
                start++;
                result = Sum / (GetSize());
                

            }
            else if (IsEmpty())
            {
                Sum = val;
                start++;
                end = start;
                buffer[start] = val;
                result = val;
            }
            else
            {
                end++;
                buffer[end] = val;
                Sum = Sum + buffer[end];
                result = Sum / GetSize();
            }
            return result;

        }

        private bool IsFull()
        {
            if (end == buffer.Length - 1 || end == start - 1)
            {
                return true;
            }
            return false;
        }

        private bool IsEmpty()
        {
            return start == -1;
        }

        private int GetSize()
        {
            if (start < end)
            {
                return end - start + 1;
            }
            else
            {
                return (buffer.Length - start) + (end + 1);
            }
        }


    }

    /**
     * Your MovingAverage object will be instantiated and called as such:
     * MovingAverage obj = new MovingAverage(size);
     * double param_1 = obj.next(val);
     */
}
