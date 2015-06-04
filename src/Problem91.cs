using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler{
    public class Problem91{
        public static void Main(string[] args){
            var coordRange = Enumerable.Range(0, 51);
            var coords = coordRange.CombineWithRepetitions(2).ToList();
            coords.RemoveAt(0);

            foreach (var coord in coords){
                //Console.WriteLine("({0}, {1})", coord[0], coord[1]);
            }

            var triangles = new HashSet<Vector2Triangle>();
            var c = Vector2.Zero;
            var coordsCount = coords.Count;
            for (var i = 0; i < coordsCount; i++) {
                var a = new Vector2(coords[i][0], coords[i][1]);
                for (var j = 0; j < coordsCount; j++) {
                    if (i == j)
                        continue;
                    var b = new Vector2(coords[j][0], coords[j][1]);
                    var triangle = new Vector2Triangle(a, b, c);
                    if (triangle.IsValidRightTriangle()) {
                        triangles.Add(triangle);
                        //Console.WriteLine(triangle);
                    }
                }
            }

            Console.WriteLine("Found {0} triangles", triangles.Count());


        }


        struct Vector2 : IEquatable<Vector2>{
            public int X { get; private set; }
            public int Y { get; private set; }

            public Vector2(int x, int y) : this(){
                X = x;
                Y = y;
            }

            public static Vector2 Zero =  new Vector2(0,0);

            public double DistanceTo(Vector2 b){
                return Math.Sqrt(Math.Pow(X - b.X, 2) + Math.Pow(Y - b.Y, 2));
            }

            public bool Equals(Vector2 other){
                return X == other.X && Y == other.Y;
            }

            public override bool Equals(object obj){
                if (ReferenceEquals(null, obj)){
                    return false;
                }
                return obj is Vector2 && Equals((Vector2) obj);
            }

            public override int GetHashCode(){
                unchecked{
                    return (X*397) ^ Y;
                }
            }

            public static bool operator ==(Vector2 left, Vector2 right){
                return left.Equals(right);
            }

            public static bool operator !=(Vector2 left, Vector2 right){
                return !left.Equals(right);
            }

            public override string ToString(){
                return String.Format("({0},{1})", X, Y);
            }
        }

        struct Vector2Triangle : IEquatable<Vector2Triangle>{
            public Vector2 A { get; private set; }
            public Vector2 B { get; private set; }
            public Vector2 C { get; private set; }

            public Vector2Triangle(Vector2 a, Vector2 b, Vector2 c) : this(){
                A = a;
                B = b;
                C = c;
            }

            public bool IsValidRightTriangle(){
                var a = A.DistanceTo(B);
                var b = B.DistanceTo(C);
                var c = C.DistanceTo(A);
                const double t = .001;
                return Math.Abs(a*a + b*b - c*c) < t || Math.Abs(b*b + c*c - a*a) < t || Math.Abs(c*c + b*b - a*a) < t;
            }

            public bool Equals(Vector2Triangle other) {
                return (A.Equals(other.A) && B.Equals(other.B)) || (A.Equals(other.B) && B.Equals(other.A));
            }

            public override bool Equals(object obj){
                if (ReferenceEquals(null, obj)){
                    return false;
                }
                return obj is Vector2Triangle && Equals((Vector2Triangle) obj);
            }

            public override int GetHashCode(){
                unchecked{
                    return A.GetHashCode() + B.GetHashCode();//b == a || a == b
                }
            }

            public static bool operator ==(Vector2Triangle left, Vector2Triangle right){
                return left.Equals(right);
            }

            public static bool operator !=(Vector2Triangle left, Vector2Triangle right){
                return !left.Equals(right);
            }

            public override string ToString(){
                return String.Format("{0}, {1}, {2}", A, B, C);
            }
        }
    }
}