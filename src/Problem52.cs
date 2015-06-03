using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    /*
    It can be seen that the number, 125874, and its double, 251748, contain exactly the 
    same digits, but in a different order.

    Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
     */
    public class Problem52{
        public static void Main(string[] args){
            
            for (var i = 1; i < 30000000; i++){
                var digits = new List<IList<int>>();
                for (var j = 1; j < 7; j++) {
                    digits.Add(Number.Digits(i * j));
                    if (j > 1){
                        if (digits[j - 1].Intersect(digits[j - 2]).Count() == digits[j - 1].Count){
                            //Console.WriteLine("i*j: " + (i*j) + ", j: " + j);
                            if (j == 6){
                                Console.WriteLine(i);
                            }
                        } else{
                            break;
                        }
                    }
                }
            }
        } 
    }
}