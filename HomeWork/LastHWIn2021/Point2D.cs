using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.LastHWIn2021
{
    public class Point2D
    {
        protected int x;
        protected int y;
        public int X { get { return x; } }
        public int Y { get { return y; }}
        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Point3D : Point2D
    {
        protected int z;
        public int Z { get { return z; } }
        public Point3D(int x, int y, int z)
            :base(x,y)
        {
            this.z = z;
        }
        public override int GetHashCode()
        {
            int hashcode = x.GetHashCode();
            hashcode = 31 * hashcode * y.GetHashCode() * z.GetHashCode();
            int module = hashcode % 10;
            return module;
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Point3D))
                throw new Exception("this is not a point");
            var a = obj as Point3D;
            if (a.X != X || a.Y != Y || a.Z != Z)
                return false;
            return true;
        }
        public override string ToString()
        {
            return x.ToString();
        }
    }
}
