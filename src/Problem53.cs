using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler{
    /*
    There are exactly ten ways of selecting three from five, 12345:

    123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

    In combinatorics, we use the notation, 5C3 = 10.

    In general,
    nCr = 	
    n!
    r!(n−r)!
	    ,where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.

    It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.

    How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?
     */
    public class Problem53{
        public static void Main(string[] args){
            var factorials = Factorials.First(1000);
            Console.WriteLine(Combinatorial.Selections(23, 10));

            //var overOneMillion = new List<BigInteger>();
            var over1mil = 0;
            for (var n = 2; n <= 100; n++){
                for (var r = 1; r <= n; r++){
                    if (Combinatorial.Selections(n, r) > 1000000){
                        //Console.WriteLine("n " + n + " r " + r);
                        over1mil++;
                    }
                }
            }
            Console.WriteLine("found " + over1mil);
        }
    }
}