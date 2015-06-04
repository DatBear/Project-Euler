using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(this IList<T> list) {
            return from m in Enumerable.Range(0, 1 << list.Count)
                select
                    from i in Enumerable.Range(0, list.Count)
                    where (m & (1 << i)) > 0
                    select list[i];
        }


        public static IEnumerable<IList<T>> CombineWithRepetitions<T>(this IEnumerable<T> input, int take) {
            ICollection<IList<T>> output = new Collection<IList<T>>();
            IList<T> item = new T[take];

            CombineWithRepetitions(output, input, item, 0);

            return output;
        }

        private static void CombineWithRepetitions<T>(ICollection<IList<T>> output, IEnumerable<T> input, IList<T> item, int count) {
            if (count < item.Count) {
                var enumerable = input as IList<T> ?? input.ToList();
                foreach (var symbol in enumerable) {
                    item[count] = symbol;
                    CombineWithRepetitions(output, enumerable, item, count + 1);
                }
            } else {
                output.Add(new List<T>(item));
            }
        }


        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IList<T> list, int p){
            return list.GetPowerSet().Where(x => x.Count() == p);
        } 
    }
}