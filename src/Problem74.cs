using System;
using System.Linq;
using System.Numerics;

namespace ProjectEuler{
    public class Problem74{
        public static void Main(string[] args){
            Console.WriteLine(String.Join(",", Factorials.SumOfDigitsFactorialsLoop(69)));
            var sixtyTerms = 0;
            for (var i = 0; i < 1000000; i++){
                if (Factorials.SumOfDigitsFactorialsLoop(i).Count() == 60){
                    sixtyTerms++;
                }
            }
            Console.WriteLine("60 terms: " + sixtyTerms);
        }
    }
}