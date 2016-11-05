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
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(new List<int>() { 1});
            list.Add(new List<int>() {  });
            Vector2D vd = new Vector2D(list);
            while(vd.HasNext())
            {
                int r = vd.Next();
            }



            //Solution s = new Solution();

            //int[] a = new int[] { 1,2,3,4,5 };

            //int i = s.FindPeakElement(a);

            int[] a = new int[] {2,2,1};
            Solution2 s = new Solution2();
            s.Permute(a);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            if (nums.Length == 1) return 0;
           
            return Helper(nums, 0, nums.Length - 1);

        }

        public int Helper(int[] a, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = low + ((high - low) / 2);

            if ((mid==0 || a[mid-1] <a[mid]) &&
                (mid == a.Length-1 || a[mid]>a[mid+1]))
            {
                return mid;
            }

            else if(mid>0 && a[mid-1]>a[mid])
            {
                return Helper(a, low, mid - 1);
            }
            else
            {
                return Helper(a, mid + 1, high);
            }
          
        }
    }

    public class Solution2
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            //IDictionary<int, int> d = new Dictionary<int, int>();
            //foreach(int i in nums)
            //{
            //    if(!d.ContainsKey(i))
            //    {
            //        d.Add(i, 1);
            //    }
            //    else
            //    {
            //        d[i] += 1;
            //    }
            //}

            Array.Sort(nums);
            perm2(result, nums, 0, nums.Length - 1);
            return result;

        }

        public static void perm(IList<IList<int>> result, int[] nums, int start, int end)
        {
            if (start == end)
            {
                int[] ele = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    
                    ele[i] = nums[i];
                    Console.Write(ele[i]);
                }
                Console.WriteLine();
                result.Add(new List<int>(ele));
            }
            else {
                for (int i = start; i <= end;      
                    i++)
                {
                    int temp = nums[start];
                    nums[start] = nums[i];
                    nums[i] = temp;

                    perm(result, nums, start + 1, end);

                    temp = nums[start];
                    nums[start] = nums[i];
                    nums[i] = temp;
                }
            }
        }

        public static void perm2(IList<IList<int>> result, int[] nums, int start, int end)
        {
            if (start == end)
            {
                int[] ele = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {

                    ele[i] = nums[i];
                    Console.Write(ele[i]);
                }
                Console.WriteLine();
                result.Add(new List<int>(ele));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                if (start != i && nums[start] == nums[i])
                {
                    continue;
                }
                int temp = nums[start];
                nums[start] = nums[i];
                nums[i] = temp;

                perm2(result, nums, start + 1, end);

                //temp = nums[start];
                //nums[start] = nums[i];
                //nums[i] = temp;
            }
        }

        private static bool IsDuplicate(int[] a, int start, int end)
        {
            for(int i = start;i< end;i++)
            {
                if (a[i] == a[start]) return true;
            }
            return false;
        }
    }
}
