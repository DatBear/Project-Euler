using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public class Problem45{
        public static void Main(string[] args){
            long max = 10000000000;
            var triangleNumbers = TriangleNumbersUnder(max);
            var pentagonalNumbers = PentagonalNumbersUnder(max);
            var hexagonalNumbers = HexagonalNumbersUnder(max);

            var allThree = hexagonalNumbers.Intersect(pentagonalNumbers).Intersect(triangleNumbers);
            foreach (var num in allThree){
                Console.WriteLine(num);
            }

            Console.Read();
        }

        static IList<long> TriangleNumbersUnder(long max){
            var numbers = new List<long>();
            for (long i = 1; i*(i + 1)/2 < max; i++){
                numbers.Add(i*(i+1)/2);
            }
            return numbers;
        }

        static IList<long> PentagonalNumbersUnder(long max) {
            var numbers = new List<long>();
            for (long i = 1; i * (3 * i - 1) / 2 < max; i++) {
                numbers.Add(i * (3 * i - 1) / 2);
                //Console.WriteLine(i * (3 * i - 1) / 2);
            }
            return numbers;
        }

        static IList<long> HexagonalNumbersUnder(long max) {
            var numbers = new List<long>();
            for (long i = 1; i * (2 * i - 1) < max; i++) {
                numbers.Add(i * (2 * i - 1));
                //Console.WriteLine(i * (2 * i - 1));
            }
            return numbers;
        }
    }
}