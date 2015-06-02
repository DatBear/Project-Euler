using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler{
    public class Number{
        public static IList<int> Digits(int num) {
            var digits = new List<int>();
            while(num > 0) {
                digits.Add(num % 10);
                num = num / 10;
            }
            digits.Reverse();
            return digits;
        }

        public static IList<int> Digits(BigInteger num) {
            var digits = new List<int>();
            while (num > 0) {
                digits.Add((int)(num % 10));
                num = num / 10;
            }
            digits.Reverse();
            return digits;
        }

        public static IList<int[]> DigitRotations(int num) {
            var digits = Digits(num);
            var queue = new Queue<int>(digits);
            var rotations = new List<int[]>{ digits.ToArray()};
            for (var i = 0; i < digits.Count-1; i++) {
                queue.Enqueue(queue.Dequeue());
                rotations.Add(queue.ToArray());
            }

            return rotations.ToList();
        }

        public static int FromDigits(int[] digits) {
            var num = 0;
            for (var i = 0; i < digits.Count(); i++) {
                num += digits[i]* (int)Math.Pow(10d, digits.Count()-1-i);
            }
            return num;
        }

        public static IList<int> FromDigitsList(IList<int[]> digits){
            return digits.Select(num => FromDigits(num)).ToList();
        }

        public static IList<int> NumberRotations(int num) {
            var digits = DigitRotations(num);
            return FromDigitsList(digits).Distinct().ToList();
        }

        public static BigInteger Reverse(BigInteger num){
            BigInteger rev = 0;
            while (num != 0) {
                rev = rev * 10 + num % 10;
                num /= 10;
            }
            return rev;
        }

        public static bool IsPalindrome(BigInteger num){
            return num == Reverse(num);
        }

        public static int Contatenate(int a, int b){
            int c = b;
            while (c > 0) {
                a *= 10;
                c /= 10;
            }
            return a + b;
        }

        public static bool IsPrime(int n) {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;
            if (n % 5 == 0) return false;

            int[] ar = new int[] { 2, 3 };
            for (int i = 0; i < ar.Length; i++) {
                if (Witness(ar[i], n)) return false;
            }
            return true;
        }


        private static bool Witness(int a, int n) {
            int t = 0;
            int u = n - 1;
            while ((u & 1) == 0) {
                t++;
                u >>= 1;
            }

            long xi1 = ModularExp(a, u, n);
            long xi2;

            for (int i = 0; i < t; i++) {
                xi2 = xi1 * xi1 % n;
                if ((xi2 == 1) && (xi1 != 1) && (xi1 != (n - 1))) return true;
                xi1 = xi2;
            }
            if (xi1 != 1) return true;
            return false;
        }

        private static long ModularExp(int a, int b, int n) {
            long d = 1;
            int k = 0;
            while ((b >> k) > 0) k++;

            for (int i = k - 1; i >= 0; i--) {
                d = d * d % n;
                if (((b >> i) & 1) > 0) d = d * a % n;
            }

            return d;
        }

        public static bool IsLychrel(int num){
            BigInteger sum = num;
            for (var i = 1; i <= 50; i++){
                sum += Reverse(sum);
                if (IsPalindrome(sum)){
                    return false;
                }
            }
            return true;
        }
    }
}