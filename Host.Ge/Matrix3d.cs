using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host.Ge
{

    public class Matrix3d : IEquatable<Matrix3d>
    {
        private double[,] m_data = new double[4, 4]
        {
            { 1,0,0,0 },
            { 0,1,0,0 },
            { 0,0,1,0 },
            { 0,0,0,1 }
        };

        public Matrix3d()
        {

        }

        public Matrix3d(
            double a00, double a01, double a02, double a03,
            double a10, double a11, double a12, double a13,
            double a20, double a21, double a22, double a23,
            double a30, double a31, double a32, double a33)
        {
            Set(
                a00, a01, a02, a03,
                a10, a11, a12, a13,
                a20, a21, a22, a23,
                a30, a31, a32, a33);
        }

        public double this[int row, int col]
        {
            get
            {
                return m_data[row, col];
            }
            set
            {
                m_data[row, col] = value;
            }
        }
        public void Set(
            double a00, double a01, double a02, double a03,
            double a10, double a11, double a12, double a13,
            double a20, double a21, double a22, double a23,
            double a30, double a31, double a32, double a33)
        {
            m_data[0, 0] = a00; m_data[0, 1] = a01; m_data[0, 2] = a02; m_data[0, 3] = a03;
            m_data[1, 0] = a10; m_data[1, 1] = a11; m_data[1, 2] = a12; m_data[1, 3] = a13;
            m_data[2, 0] = a20; m_data[2, 1] = a21; m_data[2, 2] = a22; m_data[2, 3] = a23;
            m_data[3, 0] = a30; m_data[3, 1] = a31; m_data[3, 2] = a32; m_data[3, 3] = a33;
        }
        public void SetToIdentity()
        {
            Set(
                1.0, 0.0, 0.0, 0.0,
                0.0, 1.0, 0.0, 0.0,
                0.0, 0.0, 1.0, 0.0,
                0.0, 0.0, 0.0, 1.0);
        }

        public void SetToTranslation(Vector3d v)
        {
            SetToIdentity();

            this[0, 3] = v.X;
            this[1, 3] = v.Y;
            this[2, 3] = v.Z;
        }

        public void SetToRotation(double angle, Vector3d axis)
        {
            SetToIdentity();
            Vector3d axis2 = axis.Normalized();
            double vx = axis2.X, vy = axis2.Y, vz = axis2.Z;
            m_data[0, 0] = vx * vx + (1 - vx * vx) * Math.Cos(angle);
            m_data[1, 0] = vx * vy * (1 - Math.Cos(angle)) + vz * Math.Sin(angle);
            m_data[2, 0] = vx * vz * (1 - Math.Cos(angle)) - vy * Math.Sin(angle);

            m_data[0, 1] = vx * vy * (1 - Math.Cos(angle)) - vz * Math.Sin(angle);
            m_data[1, 1] = vy * vy + (1 - vy * vy) * Math.Cos(angle);
            m_data[2, 1] = vy * vz * (1 - Math.Cos(angle)) + vx * Math.Sin(angle);

            m_data[0, 2] = vx * vz * (1 - Math.Cos(angle)) + vy * Math.Sin(angle);
            m_data[1, 2] = vy * vz * (1 - Math.Cos(angle)) - vx * Math.Sin(angle);
            m_data[2, 2] = vz * vz + (1 - vz * vz) * Math.Cos(angle);
        }

        public void SetToRotation(double angle, Vector3d axis, Point3d center)
        {


            //m_data[0,3] = (ox - vz * M) + (vz * oy - vy * oz) * Math.Sin(angle);
            //m_data[1,3] = (oy - vy * M) + (vx * oz - vz * ox) * Math.Sin(angle);
            //m_data[2,3] = (oz - vz * M) + (vy * ox - vx * oy) * Math.Sin(angle);

            Matrix3d m1 = new Matrix3d(), m2 = new Matrix3d(), m3 = new Matrix3d(), m4 = new Matrix3d();
            m1.SetToTranslation(-center.AsVector());
            m2.SetToRotation(angle, axis);
            m3.SetToTranslation(center.AsVector());
            m4 = m3 * m2 * m1;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m_data[i, j] = m4.m_data[i, j];
                }
            }
        }

        public void SetToScaling(Vector3d scale)
        {
            SetToIdentity();
            for (int i = 0; i < 3; i++)
            {
                m_data[0, i] *= scale.X;
                m_data[1, i] *= scale.Y;
                m_data[2, i] *= scale.Z;
            }
        }

        public void SetCoordSystem(Point3d origin, Vector3d xAxis, Vector3d yAxis, Vector3d zAxis)
        {

            SetToIdentity();

            m_data[0, 0] = xAxis.X;
            m_data[0, 1] = yAxis.X;
            m_data[0, 2] = zAxis.X;

            m_data[1, 0] = xAxis.Y;
            m_data[1, 1] = yAxis.Y;
            m_data[1, 2] = zAxis.Y;

            m_data[2, 0] = xAxis.Z;
            m_data[2, 1] = yAxis.Z;
            m_data[2, 2] = zAxis.Z;

            m_data[0, 3] = origin.X;
            m_data[1, 3] = origin.Y;
            m_data[2, 3] = origin.Z;

        }

        public void GetCoordSystem(Point3d origin, Vector3d xAxis, Vector3d yAxis, Vector3d zAxis)
        {
            origin.X = m_data[0, 3];
            origin.Y = m_data[1, 3];
            origin.Z = m_data[2, 3];

            xAxis.X = m_data[0, 0];
            xAxis.Y = m_data[1, 0];
            xAxis.Z = m_data[2, 0];

            yAxis.X = m_data[0, 1];
            yAxis.Y = m_data[1, 1];
            yAxis.Z = m_data[2, 1];

            zAxis.X = m_data[0, 2];
            zAxis.Y = m_data[1, 2];
            zAxis.Z = m_data[2, 2];
        }

        public static Matrix3d Translate(Vector3d v)
        {
            var m3 = new Matrix3d();
            m3.SetToTranslation(v);
            return m3;
        }

        public Matrix3d Rotate(Vector3d from, Vector3d to)
        {
            Matrix3d m3 = new Matrix3d();
            var axis = from.CrossProduct(to);
            var angle = from.AngleTo(to, axis);
            m3.SetToRotation(angle, axis);
            return m3;
        }

        public Matrix3d Rrotate(double angle, Vector3d axis)
        {
            Matrix3d m3 = new Matrix3d();
            m3.SetToRotation(angle, axis);
            return m3;
        }

        public Matrix3d Rotate(double angle, Vector3d axis, Point3d center)
        {
            Matrix3d m3 = new Matrix3d();
            m3.SetToRotation(angle, axis, center);
            return m3;
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix3d m3 && Equals(m3);
        }

        public override int GetHashCode()
        {
            return m_data.GetHashCode();
        }

        public bool Equals(Matrix3d m3)
        {
            if (m3 is null)
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (m_data[i, j] == m3.m_data[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Matrix3d operator *(Matrix3d left, Matrix3d right)
        {

            var m3 = new Matrix3d();

            double a11 = left.m_data[0, 0], a12 = left.m_data[0, 1], a13 = left.m_data[0, 2], a14 = left.m_data[0, 3];
            double a21 = left.m_data[1, 0], a22 = left.m_data[1, 1], a23 = left.m_data[1, 2], a24 = left.m_data[1, 3];
            double a31 = left.m_data[2, 0], a32 = left.m_data[2, 1], a33 = left.m_data[2, 2], a34 = left.m_data[2, 3];
            double a41 = left.m_data[3, 0], a42 = left.m_data[3, 1], a43 = left.m_data[3, 2], a44 = left.m_data[3, 3];

            double b11 = right.m_data[0, 0], b12 = right.m_data[0, 1], b13 = right.m_data[0, 2], b14 = right.m_data[0, 3];
            double b21 = right.m_data[1, 0], b22 = right.m_data[1, 1], b23 = right.m_data[1, 2], b24 = right.m_data[1, 3];
            double b31 = right.m_data[2, 0], b32 = right.m_data[2, 1], b33 = right.m_data[2, 2], b34 = right.m_data[2, 3];
            double b41 = right.m_data[3, 0], b42 = right.m_data[3, 1], b43 = right.m_data[3, 2], b44 = right.m_data[3, 3];

            m3.m_data[0, 0] = a11 * b11 + a12 * b21 + a13 * b31 + a14 * b41;
            m3.m_data[0, 1] = a11 * b12 + a12 * b22 + a13 * b32 + a14 * b42;
            m3.m_data[0, 2] = a11 * b13 + a12 * b23 + a13 * b33 + a14 * b43;
            m3.m_data[0, 3] = a11 * b14 + a12 * b24 + a13 * b34 + a14 * b44;

            m3.m_data[1, 0] = a21 * b11 + a22 * b21 + a23 * b31 + a24 * b41;
            m3.m_data[1, 1] = a21 * b12 + a22 * b22 + a23 * b32 + a24 * b42;
            m3.m_data[1, 2] = a21 * b13 + a22 * b23 + a23 * b33 + a24 * b43;
            m3.m_data[1, 3] = a21 * b14 + a22 * b24 + a23 * b34 + a24 * b44;

            m3.m_data[2, 0] = a31 * b11 + a32 * b21 + a33 * b31 + a34 * b41;
            m3.m_data[2, 1] = a31 * b12 + a32 * b22 + a33 * b32 + a34 * b42;
            m3.m_data[2, 2] = a31 * b13 + a32 * b23 + a33 * b33 + a34 * b43;
            m3.m_data[2, 3] = a31 * b14 + a32 * b24 + a33 * b34 + a34 * b44;

            m3.m_data[3, 0] = a41 * b11 + a42 * b21 + a43 * b31 + a44 * b41;
            m3.m_data[3, 1] = a41 * b12 + a42 * b22 + a43 * b32 + a44 * b42;
            m3.m_data[3, 2] = a41 * b13 + a42 * b23 + a43 * b33 + a44 * b43;
            m3.m_data[3, 3] = a41 * b14 + a42 * b24 + a43 * b34 + a44 * b44;

            return m3;
        }

        public static bool operator ==(Matrix3d left, Matrix3d right)
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

        public static bool operator !=(Matrix3d left, Matrix3d right)
        {
            return !(left == right);
        }
    }
}
