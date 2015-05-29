using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace ProjectEuler {
    /*
    In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
        1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).

    It is possible to make £2 in the following way:
        1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p

    How many different ways can £2 be made using any number of coins?
     */

    public class Problem31 {
        

        private static void Main(string[] args) {
            var coins = new int[] {
                1, 2, 5, 10, 20, 50, 100, 200
            };

            int target = 200;
            Console.WriteLine(CountCombinations(coins, target)); //242
            Console.ReadLine();
        }

        private static long CountCombinations(int[] coins, int target) {
            var table = new long[target + 1];
            table[0] = 1;
            for(int i = 0; i < coins.Length; i++) {
                for(int j = coins[i]; j <= target; j++) {
                    table[j] += table[j - coins[i]];
                }
            }
            return table[target];
        }
    }
}