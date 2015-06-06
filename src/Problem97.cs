using System;
using System.Numerics;

namespace ProjectEuler{
    public class Problem97{
        public static void Main(string[] args){
            var prime = BigInteger.Pow(2, 7830457)*28433 + 1;
            var lastDigits = prime%10000000000;
            Console.WriteLine(lastDigits);
        }
    }
}