using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host.Ge
{

    public class Vector3d : IEquatable<Vector3d>
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Vector3d()
        {

        }

        public Vector3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public double DotProduct(Vector3d vect)
        {
            return X * vect.X + Y * vect.Y + Z * vect.Z;
        }

        public Vector3d CrossProduct(Vector3d vect)
        {
            return new Vector3d(Y * vect.Z - Z * vect.Y, Z * vect.X - X * vect.Z, X * vect.Y - Y * vect.X);
        }

        public void Normalize()
        {
            double vlen = Length();
            if (vlen == 0.0)
            {
                return;
            }
            X /= vlen;
            Y /= vlen;
            Z /= vlen;
        }

        public Vector3d Normalized()
        {

            Vector3d v = new Vector3d(X, Y, Z);
            v.Normalize();
            return v;
        }

        public bool IsParallelTo(Vector3d v)
        {
            return X * v.Y == v.X * Y && X * v.Z == v.X * Z && Y * v.Z == v.Y * Z;
        }

        public double AngleTo(Vector3d v)
        {
            if (Length() == 0.0 || v.Length() == 0.0)
            {
                return 0.0;
            }
            return Math.Acos(DotProduct(v) / (v.Length() * Length()));
        }

        public double AngleTo(Vector3d v, Vector3d refVector)
        {
            Vector3d v2 = CrossProduct(v);
            double dot = v2.DotProduct(refVector);
            double ang = AngleTo(v);
            if (dot > 0)
            {
                return ang;
            }
            else
            {
                return Math.PI * 2.0 - ang;
            }
            return 0.0;
        }

        public Vector3d PerpVector()
        {
            if (X != 0)
            {
                return new Vector3d(-Y, X, 0.0).Normalized();
            }

            else if (Y != 0)
            {
                return new Vector3d(-Y, X, 0.0).Normalized();
            }
            else if (Z != 0)
            {
                return new Vector3d(-Z, 0.0, X).Normalized();
            }
            else
            {
                return new Vector3d();
            }
        }

        public bool IsZero()
        {
            return X == 0.0 && Y == 0.0 && Z == 0.0;
        }

        public void SetLength(double len)
        {
            if (IsZero())
            {
                X = Math.Sqrt(len * len / 3);
                Y = X;
                Z = X;
            }
            else
            {
                double t = Math.Abs(len) / Length();
                X *= t;
                Y *= t;
                Z *= t;
            }
        }

        public double LengthSquared()
        {
            return X * X + Y * Y + Z * Z;
        }

        public void Transform(Matrix3d mat)
        {

            Vector3d v1 = new Vector3d(mat[0, 0], mat[1, 0], mat[2, 0]);
            Vector3d v2 = new Vector3d(mat[0, 1], mat[1, 1], mat[2, 1]);
            Vector3d v3 = new Vector3d(mat[0, 2], mat[1, 2], mat[2, 2]);

            Vector3d v = v1 * X + v2 * Y + v3 * Z;
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3d v)
            {
                return Equals(v);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X.ToString() + Y.ToString() + Z.ToString()).GetHashCode();
        }

        public bool Equals(Vector3d v)
        {
            return v is null ? false : v.X == X && v.Y == Y && v.Z == Z;
        }

        public static Vector3d operator +(Vector3d left, Vector3d right)
        {
            return new Vector3d(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3d operator -(Vector3d left, Vector3d right)
        {
            return new Vector3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3d operator -(Vector3d vec)
        {
            return new Vector3d(-vec.X, -vec.Y, -vec.Z);
        }

        public static bool operator ==(Vector3d left, Vector3d right)
        {
            if (left is null && right is null)
            {
                return true;
            }
            else if (left is null || right is null)
            {
                return false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(Vector3d left, Vector3d right)
        {
            return !(left == right);
        }

        public static Vector3d operator *(Vector3d left, double right)
        {
            return new Vector3d(left.X * right, left.Y * right, left.Z * right);
        }

        public static Vector3d operator /(Vector3d left, double right)
        {
            return new Vector3d(left.X / right, left.Y / right, left.Z / right);
        }
    }
}
