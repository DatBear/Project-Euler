using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler {

    /*
    Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

    For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. 
    The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    Evaluate the sum of all the amicable numbers under 10000.
     */
    public class Problem21 {
        static void Main(string[] args) {
            var sum220 = ProperDivisorsSum(220);
            Console.WriteLine(sum220 + ", " + IsAmicableNumber(220));

            int sum = 0;
            for (var i = 1; i < 10000; i++) {
                if (IsAmicableNumber(i)) {
                    Console.WriteLine(IsAmicableNumber(i) + ", " + i + ", " + ProperDivisorsSum(i));
                }
                sum += IsAmicableNumber(i) ? i : 0;
            }
            Console.WriteLine(sum);
        }

        public static int ProperDivisorsSum(int num) {
            int sum = 0;
            for (var i = 1; i < num; i++) {
                sum += num%i == 0 ? i : 0;
            }
            return sum;
        }

        static bool IsAmicableNumber(int num) {
            var sum = ProperDivisorsSum(num);
            return num == ProperDivisorsSum(sum) && num != sum;
        }
    }
}