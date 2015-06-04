using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public class Problem92 {
        public static void Main(string[] args){
            Console.WriteLine(String.Join(",", SumOfDigitsSquaresChain(44)));
            var max = 10000000;
            var eightyNine = 0;
            for (var i = 0; i < max; i++){
                var chain = SumOfDigitsSquaresChain(i);
                if (chain.Contains(89)){
                    eightyNine++;
                }
            }
            Console.WriteLine("terms ending in 89: {0}", eightyNine);
        }

        static int[] SumOfDigitsSquaresChain(int num){
            var terms = new List<int>();
            var sum = num;
            while (!terms.Contains(sum)) {
                terms.Add(sum);
                sum = SumOfDigitsSquares(sum);
            }
            return terms.ToArray();
        }

        public static int SumOfDigitsSquares(int num) {
            var sum = 0;
            while (num > 0) {
                sum += (num % 10)*(num % 10);
                num = num / 10;
            }
            return sum;
        }


    }
}