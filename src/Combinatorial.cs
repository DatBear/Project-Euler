using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler{
    public class Combinatorial {
        private static BigInteger[] factorials = Factorials.First(1000);

        /// <summary>
        /// Combinatorial # of selections
        /// </summary>
        /// <param name="n">size of collection</param>
        /// <param name="r">number of selections</param>
        /// <returns></returns>
        public static BigInteger Selections(int n, int r) {
            return factorials[n]/(factorials[r]*factorials[n - r]);
        }

        public static IEnumerable<T[]> AllCombinations<T>(T[] values, int k){
            var combinations = new List<T[]>();
            for (var i = 0; i < values.Count(); i++){
                var current = new T[values.Count()];
                for (var j = 0; j < values.Count(); j++){
                    if (i == j){
                        continue;
                    }

                }
            }
            return combinations;
        }
    }
}