namespace ComputerGraphicsLab.Entities
{
    public abstract class Shape
    {
        static public PointF CalculateRotationCoordinate(PointF point, PointF slide, float gradus)
        {
            float sin = float.Sin(gradus * float.Pi / 180);
            float cos = float.Cos(gradus * float.Pi / 180);

            float m = -slide.X;
            float n = -slide.Y;
            float k = -m;
            float l = -n;
            var x = point.X;
            var y = point.Y;
            var dx = x * cos - y * sin + m * cos - n * sin + k;
            var dy = x * sin + y * cos + m * sin + n * cos + l;

            return new PointF(dx, dy);
        }

        public abstract void MoveShape(float x = 0, float y = 0);

        public abstract void Draw(Pen pen, Graphics graphics);

        static public PointF ScalePoint(PointF point1,PointF slide, float scale)
        {
            var dx = -point1.Y * (slide.X - point1.X) / (slide.Y - point1.Y);
            dx += point1.X;
            var x = point1.X + float.Abs(dx);
            var y = point1.Y;
            var gradus = double.Atan(y/x);

            var sina = double.Sin(-gradus);
            var cosa = double.Cos(-gradus);
            var sinb = double.Sin(gradus);
            var cosb = double.Cos(gradus);

            var e1 = x * cosa - y * sina;
            var e2 = x * sina + y * cosa;

            e1 += scale;

            var e1_ = e1 * cosb - e2 * sinb;
            var e2_ = e1 * sinb + e2 * cosb;

            e1_ -= float.Abs(dx);

            var dx_ = (float)e1_;
            var dy_ = (float)e2_;

            return new PointF(dx_, dy_);
        }
    }
}
