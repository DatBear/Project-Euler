using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public class Problem60{
        private static IList<int> _p = Primes.Under(30000);


        public static void Main(string[] args){
            Console.WriteLine(_p.IndexOf(673109));
            Console.WriteLine(_p.IndexOf(109));

            var found = false;
            for (var i = 10; i < _p.Count() && !found; i++){
                for (var j = 0; j < i; j++){
                    if (AreAllPrime(_p[i], _p[j])){
                        for (var k = 0; k < j; k++){
                            if (AreAllPrime(_p[i], _p[j], _p[k])){
                                //Console.WriteLine("3 prime group i " + i + " j " + j + " k " + k + " _p[i] " + _p[i]);
                                for (var l = 0; l < k; l++){
                                    if (AreAllPrime(_p[i], _p[j], _p[k], _p[l])){
                                        Console.WriteLine("4 prime group i " + i + " j " + j + " k " + k + " l " + l + " _p[i] " + _p[i]);
                                        for (var m = 0; m < l; m++){
                                            if (AreAllPrime(_p[i], _p[j], _p[k], _p[l], _p[m])){
                                                Console.WriteLine("5 prime group i " + i + " j " + j + " k " + k + " l " +
                                                                  l + " m " + m + " _p[i] " + _p[i]);
                                                Console.WriteLine("sum " + (_p[i] + _p[j] + _p[k] + _p[l] + _p[m]));
                                                found = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(found ? "found" : "not found");
        }

        private static bool AreAllPrime(params int[] numbers){
            var len = numbers.Count();
            for (var i = 0; i < len; i++){
                for (var j = 0; j < len; j++){
                    if (j == i){
                        continue;
                    }
                    var concatenated = Number.Contatenate(numbers[i], numbers[j]);
                    if (!Number.IsPrime(concatenated)){
                        return false;
                    }
                }
            }

            return true;
        }
    }
}