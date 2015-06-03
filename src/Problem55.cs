using System;
using System.Numerics;

namespace ProjectEuler{
    public class Problem55{
        public static void Main(string[] args){
            Console.WriteLine(Number.Reverse(123456789));
            Console.WriteLine(Number.IsLychrel(9998));

            var lychrelNumbers = 0;
            for (var i = 10; i < 10000; i++) {
                if (Number.IsLychrel(i)) {
                    Console.WriteLine(i);
                    lychrelNumbers++;
                }
            }
            Console.WriteLine(lychrelNumbers);
        }
    }
}