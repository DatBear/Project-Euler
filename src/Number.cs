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
    }
}