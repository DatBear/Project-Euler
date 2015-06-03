using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    /*
    If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, 
    there are exactly three solutions for p = 120.

    {20,48,52}, {24,45,51}, {30,40,50}

    For which value of p ≤ 1000, is the number of solutions maximised?
     */
    public class Problem39 {
        public static void Main(string[] args){

            var triangles120 = FindTriangles(120);
            foreach (var triangle in triangles120){
                Console.WriteLine("a: " + triangle.A() + ", b: " + triangle.B() + ", c: " + triangle.C());
            }

            int mostTriangles = 0;
            int mostTrianglesPerimiter = 0;

            for (var i = 1; i <= 1000; i++){
                var triangles = FindTriangles(i);
                if (triangles.Count > mostTriangles){
                    mostTriangles = triangles.Count;
                    mostTrianglesPerimiter = i;
                }
            }

            Console.WriteLine("# of triangles: "+ mostTriangles + ", perimeter: " + mostTrianglesPerimiter);
        }

        static IList<Triangle> FindTriangles(int perimeter){
            IList<Triangle> triangles = new List<Triangle>();
            for (var a = 2; a < perimeter; a++) {
                for (var b = 1; b < a; b++) {
                    var triangle = new Triangle(a, b);
                    if (triangle.IsRight() && triangle.Perimeter() == perimeter) {
                        if (!triangles.Contains(triangle)){
                            triangles.Add(triangle);
                        }
                    }
                }
            }
            return triangles.ToList();
        }



        struct Triangle : IEquatable<Triangle>{
            private readonly int _a;
            private readonly int _b;
            private readonly int _c;

            public Triangle(int a, int b){
                this._a = a;
                this._b = b;
                
                var c = Math.Sqrt(a*a + b*b);
                if (Math.Abs(c%1) < .00001){
                    this._c = (int) c;
                } else{
                    this._c = -1;
                }
            }

            public int A(){
                return _a;
            }

            public int B(){
                return _b;
            }

            public int C(){
                return _c;
            }

            public bool IsRight(){
                return _c != -1;
            }

            public int Perimeter(){
                return _a + _b + _c;
            }

            public bool Equals(Triangle other){
                return (_a == other._a && _b == other._b) || (_b == other._a && _a == other._b);
            }

            public override bool Equals(object obj){
                if (ReferenceEquals(null, obj)){
                    return false;
                }
                return obj is Triangle && Equals((Triangle) obj);
            }

            public override int GetHashCode(){
                unchecked{
                    return (_a*397) ^ _b;
                }
            }

            public static bool operator ==(Triangle left, Triangle right){
                return left.Equals(right);
            }

            public static bool operator !=(Triangle left, Triangle right){
                return !left.Equals(right);
            }
        }
    }
}