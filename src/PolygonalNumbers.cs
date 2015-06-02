using System;
using System.Collections.Generic;

namespace ProjectEuler{
    public class PolygonalNumbers{
        public static IList<long> TriangleNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*(i + 1)/2 < max; i++){
                numbers.Add(i*(i + 1)/2);
            }
            return numbers;
        }

        public static IList<long> SquareNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*i < max; i++){
                numbers.Add(i*i);
                //Console.WriteLine(i * i);
            }
            return numbers;
        }

        public static IList<long> PentagonalNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*(3*i - 1)/2 < max; i++){
                numbers.Add(i*(3*i - 1)/2);
                //Console.WriteLine(i * (3 * i - 1) / 2);
            }
            return numbers;
        }

        public static IList<long> HexagonalNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*(2*i - 1) < max; i++){
                numbers.Add(i*(2*i - 1));
                //Console.WriteLine(i * (2 * i - 1));
            }
            return numbers;
        }

        public static IList<long> HeptagonalNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*(5*i - 3)/2 < max; i++){
                numbers.Add(i*(5*i - 3)/2);
                //Console.WriteLine(i * (5 * i - 3)/2);
            }
            return numbers;
        }

        public static IList<long> OctagonalNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*(3*i - 2) < max; i++){
                numbers.Add(i*(3*i - 2));
                //Console.WriteLine(i * (3 * i - 2));
            }
            return numbers;
        }
    }
}