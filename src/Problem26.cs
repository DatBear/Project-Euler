using System;

namespace ProjectEuler {
    public class Problem26 {
        public static void Main(string[] args) {
            var divs = long_division(1, 7);
            Console.WriteLine(String.Join("", divs));


            var longestNum = 1;
            var longestLength = 1;
            for (var i = 2; i < 1000; i++) {
                var result = i%2 != 0 && i%5 != 0 ? long_division(1, i) : new int[0];
                if (result.Length > longestLength) {
                    longestNum = i;
                    longestLength = result.Length;
                }
            }
            Console.WriteLine("Longest num: " + longestNum + ", longest length: " + longestLength);
            

            Console.Read();
        }


        static string FractionalPart(decimal n) {
            string s = n.ToString("#.####################################", System.Globalization.CultureInfo.InvariantCulture);
            return s.Substring(s.IndexOf(".") + 1);
        }

        static int[] long_division(int numerator, int denominator) {
            if(numerator < 1 || numerator >= denominator)
                throw new Exception("Bad call");
            // now we know 0 < numerator < denominator
            if(denominator % 2 == 0 || denominator % 5 == 0)
                throw new Exception("Bad denominator");
            // now we know we get a purely periodic expansion
            int[] digits = new int[denominator];
            int k = 0, n = numerator;
            do {
                n *= 10;
                digits[k++] = n / denominator;
                n = n % denominator;
            } while(n != numerator);
            int[] period = new int[k];
            for(n = 0; n < k; ++n) {
                period[n] = digits[n];
            }
            return period;
        }
    }
}