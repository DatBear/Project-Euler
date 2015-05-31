using System;
using System.Numerics;

namespace ProjectEuler{
    public class Factorials{
        //public static long[] First(int num){
        //    var factorials = new long[num+1];
        //    factorials[0] = 1;
        //    for (long i = 1; i < factorials.Length; i++) {
        //        factorials[i] = factorials[i-1] * i;
        //    }
        //    return factorials;
        //}

        public static BigInteger[] First(int num) {
            var factorials = new BigInteger[num + 1];
            factorials[0] = 1;
            for (long i = 1; i < factorials.Length; i++) {
                factorials[i] = factorials[i - 1] * i;
            }
            return factorials;
        }
    }
}