using System;

namespace ProjectEuler {
    /*
    145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

    Find the sum of all numbers which are equal to the sum of the factorial of their digits.

    Note: as 1! = 1 and 2! = 2 are not sums they are not included.
     */
    public class Problem34 {
        public static void Main(string[] args) {
            Console.WriteLine(String.Join(",", factorials));
            Console.WriteLine(SumFactorialOfDigits(145));

            var sum = 0;
            for (var i = 10; i < 10000000; i++) {
                sum += i == SumFactorialOfDigits(i) ? i : 0;
            }
            Console.WriteLine(sum);

            Console.Read();
        }

        private static int[] factorials = Factorials();

        static int[] Factorials() {
            var factorials = new int[10];
            factorials[0] = 1;
            for (var i = 1; i < factorials.Length; i++) {
                factorials[i] = 1;
                for (var j = 1; j <= i; j++) {
                    factorials[i] *= j;
                }
            }
            return factorials;
        }

        static int SumFactorialOfDigits( int num) {
            var sum = 0;
            while (num > 0) {
                sum += factorials[num%10];
                num = num/10;
            }
            return sum;
        }
    }
}