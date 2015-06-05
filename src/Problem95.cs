using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public class Problem95{
        public static void Main(string[] args){
            Console.WriteLine(Number.ProperDivisorsSum(220));
            Console.WriteLine(String.Join(",", AmicableNumberChain(12496)));

            int longestChain = 0;
            int longestChainMin = 0;
            for (var i = 1; i < 1000000; i++){
                var chain = AmicableNumberChain(i);
                if (chain.Count() > longestChain && chain.Max() < 1000000){
                    longestChain = chain.Count();
                    longestChainMin = chain.Min();
                    Console.WriteLine("i {0}, chain {1}, min {2}", i, longestChain, longestChainMin);
                }

            }
            Console.WriteLine(longestChainMin);
        }

        static int[] AmicableNumberChain(int num){
            var chain = new List<int>();
            var sum = num;
            while (!chain.Contains(sum)){
                chain.Add(sum);
                sum = Number.ProperDivisorsSum(sum);
            }
            return chain[0] == sum ? chain.ToArray() : new int[0];
        }

    }
}