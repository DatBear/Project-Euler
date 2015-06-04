using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler{
    public class Factorials{
        private static BigInteger[] forDigits = First(9);

        public static BigInteger[] First(int num) {
            var factorials = new BigInteger[num + 1];
            factorials[0] = 1;
            for (long i = 1; i < factorials.Length; i++) {
                factorials[i] = factorials[i - 1] * i;
            }
            return factorials;
        }

        public static int SumOfDigitsFactorials(int num) {
            var sum = 0;
            while (num > 0) {
                sum += (int)forDigits[num % 10];
                num = num / 10;
            }
            return sum;
        }

        public static int[] SumOfDigitsFactorialsChain(int num){
            var terms = new List<int>();
            var sum = num;
            while (!terms.Contains(sum)){
                terms.Add(sum);
                sum = SumOfDigitsFactorials(sum);
            }
            return terms.ToArray();
        }
    }
}