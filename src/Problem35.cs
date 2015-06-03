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
                    var rotations = Number.NumberRotations(prime);
                    if (TargetPrimes.Intersect(rotations).Count() == rotations.Count()) {
                        foreach (var num in rotations) {
                            circularPrimes.Add(num);
                            Console.WriteLine(num);
                        }
                    }
                }
            }

            Console.WriteLine(circularPrimes.Count + " circular primes found");
        }

        private static IList<int> TargetPrimes = Primes.Under(1000000);
    }
}