using static System.Windows.Forms.LinkLabel;

namespace ComputerGraphicsLab.Entities
{
    public class Line : Shape
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

        public override void Draw(Pen pen, Graphics graphics)
        {
            graphics.DrawLine(pen, point1, point2);
        }

        public override void MoveShape(float x = 0, float y = 0)
        {
            point1.X += x;
            point2.X += x;
            point1.Y += y;
            point2.Y += y;
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

        public void RotateLine(PointF slide, float gradus)
        {
            var p1_line1 = CalculateRotationCoordinate(Point1, slide, gradus);
            var p2_line1 = CalculateRotationCoordinate(Point2, slide, gradus);
            SetCoordinates(p1_line1, p2_line1);
        }

        public void RotatePoint1(PointF slide, float gradus)
        {
            var p1 = CalculateRotationCoordinate(Point1, slide, gradus);

            SetCoordinates(point1: p1);
        }

        public void RotatePoint2(PointF slide, float gradus)
        {
            var p2 = CalculateRotationCoordinate(Point2, slide, gradus);

            SetCoordinates(point2: p2);
        }

        public bool LimitXRight(int x)
        {
            if (point1.X >= x || point2.X >= x)
                return false;
            return true;
        }
        public bool LimitXLeft(int x)
        {
            if (point1.X <= x || point2.X <= x)
                return false;
            return true;
        }

        public void Scale(float scale)
        {
            point1 = ScalePoint(point1, point2, scale);
            point2 = ScalePoint(point2, point1, scale);
        }
    }
}
