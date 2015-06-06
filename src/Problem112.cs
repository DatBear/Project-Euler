using System;
using System.Numerics;

namespace ProjectEuler{
    public class Problem112{
        public static void Main(string[] args){
            Console.WriteLine(IsBouncy(112));
            var bouncies = 0;
            BigInteger i;
            for (i = new BigInteger(2); i >= 0; i++){
                if (IsBouncy(i)){
                    bouncies++;
                }
                if (bouncies*100 >= i*99){
                    break;
                }
            }

            Console.WriteLine(i);


        }

        static bool IsBouncy(BigInteger num){
            var digits = Number.Digits(num);
            var increasing = false;
            var decreasing = false;
            for (var i = 0; i < digits.Count-1; i++){
                if (digits[i] < digits[i + 1] && !increasing){
                    increasing = true;
                } else if (digits[i] > digits[i + 1] && !decreasing){
                    decreasing = true;
                } else if (increasing && decreasing){
                    return true;
                }
            }
            return increasing && decreasing;
        }


    }
}