namespace ComputerGraphicsLab.Entities
{
    public class Line
    {
        PointF point1;
        PointF point2;
        public PointF Point1 => point1;
        public PointF Point2 => point2;
        public Line(PointF point1, PointF point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public void Draw(Pen pen, Graphics graphics)
        {
            graphics.DrawLine(pen, point1, point2);
        }

        public void MoveShapeX(int dx)
        {
            point1.X += dx;
            point2.X += dx;
        }

        public void MoveShapeY(int dy)
        {
            point1.Y += dy;
            point2.Y += dy;
        }

        public void SetCoordinates(PointF? point1 = null, PointF? point2 = null)
        {
            if (point1 != null)
            {
                this.point1.X = point1.Value.X;
                this.point1.Y = point1.Value.Y;
            }
            if (point2 != null)
            {
                this.point2.X = point2.Value.X;
                this.point2.Y = point2.Value.Y;
            }
        }

        public void SetCoordinates(int x1, int y1, int x2, int y2)
        {
            point1.X = x1;
            point1.Y = y1;
            point2.X = x2;
            point2.Y = y2;
        }
    }
}
