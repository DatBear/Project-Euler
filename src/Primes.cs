using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler {
    public class Primes {

        public static IList<int> Under(int max) {
            BitArray PrimeBits = new BitArray(max, true);

            PrimeBits.Set(0, false); // You don't actually need this, just
            PrimeBits.Set(1, false); // remindig you that 2 is the smallest prime

            int maxSqrt = (int) Math.Sqrt(max);
            for(int P = 2; P < maxSqrt + 1; P++)
                if(PrimeBits.Get(P))
                    // These are going to be the multiples of P if it is a prime
                    for(int PMultiply = P * 2; PMultiply < max; PMultiply += P)
                        PrimeBits.Set(PMultiply, false);

            // We use this to store the actual prime numbers
            List<int> Primes = new List<int>();

            for(int i = 2; i < max; i++)
                if (PrimeBits.Get(i)) {
                    Primes.Add(i);
                }
            return Primes;
        }
    }
}