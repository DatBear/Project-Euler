using System;
using System.Numerics;

namespace ProjectEuler{
    public class Problem55{
        public static void Main(string[] args){
            Console.WriteLine(Number.Reverse(123456789));
            Console.WriteLine(IsLychrelNumber(9998));

            var lychrelNumbers = 0;
            for (var i = 10; i < 10000; i++) {
                if (IsLychrelNumber(i)) {
                    Console.WriteLine(i);
                    lychrelNumbers++;
                }
            }
            Console.WriteLine(lychrelNumbers);

            Console.Read();
        }

        static bool IsLychrelNumber(int num){
            BigInteger sum = num;
            for (var i = 1; i <= 50; i++){
                //Console.WriteLine("sum " + sum + " + " + Number.Reverse(sum) + " = " + (sum + Number.Reverse(sum)));
                sum += Number.Reverse(sum);
                if (Number.IsPalindrome(sum)){
                    return false;
                }
            }
            return true;
        }


    }
}