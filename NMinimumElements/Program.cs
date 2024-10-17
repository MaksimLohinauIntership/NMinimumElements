using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMinimumElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 77, 3, 99, 2, 11, 5, 4,38, 22 };

            var i = list.Min(3);
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<int> Min(this IEnumerable<int> collection, int n)
        {
            if (collection == null)
                throw new InvalidOperationException("Collection can't be an empty.");
            if (n < 1) 
                throw new ArgumentOutOfRangeException(nameof(n), "N must be greater than 0.");

            List<int> minValues = new List<int>();

            List<int> list = new List<int>(collection);
            int temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for(int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                minValues.Add(list[i]);
            }

            return minValues;
        }
    }
}
