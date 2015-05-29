using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler {
    public class Problem35 {
        public static void Main(string[] args) {
            Console.WriteLine(Primes.Under(1000000).Count);

            //var rotations = DigitRotations(197);
            //foreach(var rotation in rotations) {
            //    Console.WriteLine(String.Join(",", rotation));
            //    Console.WriteLine(FromDigits(rotation));
            //}

            var circularPrimes = new List<int>();
            for (var i = 0; i < TargetPrimes.Count; i++) {
                var prime = TargetPrimes[i];
                if(!circularPrimes.Contains(prime)) {
                    var rotations = NumberRotations(prime);
                    if (TargetPrimes.Intersect(rotations).Count() == rotations.Count()) {
                        foreach (var num in rotations) {
                            circularPrimes.Add(num);
                            Console.WriteLine(num);
                        }
                    }
                }
            }

            Console.WriteLine(circularPrimes.Count + " circular primes found");

            Console.Read();
        }

        private static IList<int> TargetPrimes = Primes.Under(1000000);

        static IList<int> Digits(int num) {
            var digits = new List<int>();
            while(num > 0) {
                digits.Add(num % 10);
                num = num / 10;
            }
            digits.Reverse();
            return digits;
        }

        static IList<int[]> DigitRotations(int num) {
            var digits = Digits(num);
            var queue = new Queue<int>((List<int>)digits);
            var rotations = new List<int[]>{ digits.ToArray()};
            for (var i = 0; i < digits.Count-1; i++) {
                queue.Enqueue(queue.Dequeue());
                rotations.Add(queue.ToArray());
            }

            return rotations.ToList();
        }

        static int FromDigits(int[] digits) {
            var num = 0;
            for (var i = 0; i < digits.Count(); i++) {
                num += digits[i]* (int)Math.Pow(10d, digits.Count()-1-i);
            }
            return num;
        }

        static IList<int> FromDigitsList(IList<int[]> digits) {
            var numbers = new List<int>();
            foreach (var num in digits) {
                numbers.Add(FromDigits(num));
            }
            return numbers;
        }

        static IList<int> NumberRotations(int num) {
            var digits = DigitRotations(num);
            return FromDigitsList(digits).Distinct().ToList();
        }
    }
}