using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public class Problem45{
        public static void Main(string[] args){
            long max = 10000000000;
            var triangleNumbers = PolygonalNumbers.TriangleNumbersUnder(max);
            var pentagonalNumbers = PolygonalNumbers.PentagonalNumbersUnder(max);
            var hexagonalNumbers = PolygonalNumbers.HexagonalNumbersUnder(max);

            var allThree = hexagonalNumbers.Intersect(pentagonalNumbers).Intersect(triangleNumbers);
            foreach (var num in allThree){
                Console.WriteLine(num);
            }
        }
    }
}