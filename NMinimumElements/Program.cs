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
            var list = new List<int>() { 77, 3, 99, 2, 11, 5, 4,38, 22,122,143,7,8,94,21 };

            var i = list.Min(7);
            Console.ReadLine();
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

            LinkedList<int> result = new LinkedList<int>();

            foreach (var item in collection)
            {
                if (result.Count < n)
                {
                    AddInSortedOrder(result, item);
                }
                else
                {
                    if (item < result.Last.Value)
                    {
                        result.RemoveLast();
                        AddInSortedOrder(result, item);
                    }
                }
            }

            return result;
        }
        private static void AddInSortedOrder(LinkedList<int> list, int item)
        {
            if (list.Count == 0)
            {
                list.AddFirst(item);
                return;
            }

            var current = list.First;
            while (current != null && current.Value < item)
            {
                current = current.Next;
            }

            if (current == null) // Если дошли до конца списка
            {
                list.AddLast(item);
            }
            else if (current == list.First) // Если элемент меньше самого маленького
            {
                list.AddFirst(item);
            }
            else // Вставляем перед текущим элементом
            {
                list.AddBefore(current, item);
            }
        }
    }
}
