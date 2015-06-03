using System;

namespace ProjectEuler {
    /*
    The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

    We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

    There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

    If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
     */
    public class Problem33 {
        public static void Main(string[] args) {
            PrintFractions();
        }

        private double[] simplifiedFractions = {
            1/2, 3/4, 3/5, 3/6, 3/7, 3/8, 3/9
        };

        static void PrintFractions() {
            for (var n = 1; n < 100; n++) {
                for (var d = n+1; d < 100; d++) {
                    if(d % 10 != 0 && n % 10 == d / 10 && Math.Abs((double)n / d - ((double)(n / 10) / (d % 10))) < .001) {
                        Console.WriteLine(n + "/" + d + ":" + (n / 10) +"/"+ (d % 10));
                    }
                }
            }
            Console.WriteLine(".");
        }
    }
}