using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler {
    /*
    A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

    A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

    As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

    Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
     */
    public class Problem23 {
        public static void Main(string[] args) {
            Console.WriteLine(IsAbundantNumber(12));

            var abundantNumbers = new List<int>();
            for (var i = 1; i < 28124; i++) {
                if (IsAbundantNumber(i)) {
                    abundantNumbers.Add(i);
                }
            }

            Console.WriteLine(SumOfNoSumOfTwo(abundantNumbers));

            //Console.WriteLine(String.Join(", ", abundantNumbers));

            Console.Read();
        }

        static int SumOfNoSumOfTwo(IEnumerable<int> pool) {
            bool[] sumsReached = new bool[pool.Last()+1];
            foreach (int a in pool) {
                foreach (int b in pool) {
                    if (a + b <= pool.Last()) {
                        sumsReached[a + b] = true;
                    }
                }
            }
            int sum = 0;
            for (var i = 0; i < sumsReached.Length; i++) {
                sum += !sumsReached[i] ? i : 0;
            }
            return sum;
        }

        static bool IsAbundantNumber(int num) {
            var sum = Problem21.ProperDivisorsSum(num);
            return sum > num;
        }
    }
}