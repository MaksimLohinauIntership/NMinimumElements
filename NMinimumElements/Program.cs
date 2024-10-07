using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMinimumElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 3, 99, 2, 4, 11, 22, 24, 21, 25 };

            var i = list.Min(3);
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Min<TSource>(this IEnumerable<TSource> source, int n) where TSource : IComparable<TSource>
        {
            if (source == null) throw new ArgumentNullException("List is empty");
            if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "N must be greater than 0.");

            return source.OrderBy(x => x).Take(n);
        }
    }
}
