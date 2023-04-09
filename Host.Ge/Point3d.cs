using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host.Ge
{
    public class Point3d : IEquatable<Point3d>
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public Point3d()
        {

        }

        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3d AsVector()
        {
            return new Vector3d(X, Y, Z);
        }

        public double DX(Point3d pt)
        {
            return pt.X - X;
        }

        public double DY(Point3d pt)
        {
            return pt.Y - Y;
        }

        public double DZ(Point3d pt)
        {
            return pt.Z - Z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3d pt)
            {
                Equals(pt);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X.ToString() + Y.ToString() + Z.ToString()).GetHashCode();
        }

        public void Transform(Matrix3d mat)
        {
            Vector3d v1 = new Vector3d(mat[0, 0], mat[1, 0], mat[2, 0]);
            Vector3d v2 = new Vector3d(mat[0, 1], mat[1, 1], mat[2, 1]);
            Vector3d v3 = new Vector3d(mat[0, 2], mat[1, 2], mat[2, 2]);

            Vector3d v = v1 * X + v2 * Y + v3 * Z;
            X = v.X + mat[0, 3];
            Y = v.Y + mat[1, 3];
            Z = v.Z + mat[2, 3];
        }

        public double DistanceTo(Point3d pt)
        {
            return (this - pt).Length();
        }

        public bool Equals(Point3d pt)
        {
            if (pt is null)
            {
                return false;
            }
            return pt.X == X && pt.Y == Y && pt.Z == Z;
        }

        public static Vector3d operator -(Point3d left, Point3d right)
        {
            return new Vector3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public static Point3d operator +(Point3d left, Vector3d right)
        {
            return new Point3d(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        public static Point3d operator -(Point3d left, Vector3d right)
        {
            return new Point3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static bool operator ==(Point3d left, Point3d right)
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

        public static bool operator !=(Point3d left, Point3d right)
        {
            return !(left == right);
        }
    }
}
