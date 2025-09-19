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
    }
}
