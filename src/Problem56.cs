using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler{
    public class Problem56{
        public static void Main(string[] args){

            int maxSum = 0;
            for (BigInteger i = 1; i < 100; i++){
                for (var j = 1; j < 100; j++){
                    var result = BigInteger.Pow(i, j);
                    var digits = Number.Digits(result);
                    if (digits.Sum() > maxSum){
                        maxSum = digits.Sum();
                    }
                }
            }
            Console.WriteLine("max sum " + maxSum);

            Console.Read();
        }



    }
}