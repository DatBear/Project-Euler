using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public static class EnumerableUtil{

        public static void Shuffle<T>(this IList<T> list) {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(IList<T> list) {
            return from m in Enumerable.Range(0, 1 << list.Count)
                select
                    from i in Enumerable.Range(0, list.Count)
                    where (m & (1 << i)) != 0
                    select list[i];
        }
    }
}