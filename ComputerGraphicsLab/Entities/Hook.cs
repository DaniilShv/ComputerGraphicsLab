using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComputerGraphicsLab.Entities
{
    public class Hook
    {
        Line line1;
        Line line2;
        Line line3;

        public Hook(Line line1, Line line2, Line line3)
        {
            this.line1 = line1;
            this.line2 = line2;
            this.line3 = line3;
        }

        public void Draw(Pen pen, Graphics graphics)
        {
            line1.Draw(pen, graphics);
            line2.Draw(pen, graphics);
            line3.Draw(pen, graphics);
        }

        public void MoveShapeX(int dx)
        {
            line1.MoveShapeX(dx);
            line2.MoveShapeX(dx);
            line3.MoveShapeX(dx);
        }

        public void MoveShapeY(int dy)
        {
            line1.MoveShapeY(dy);
            line2.MoveShapeY(dy);
            line3.MoveShapeY(dy);
        }

        public void MoveRelatingLine(Line line)
        {
            var p1_line1 = CalculateRotationCoordinates(line1.Point1, line.Point1);
            var p2_line1 = CalculateRotationCoordinates(line1.Point2, line.Point1);
            line1.SetCoordinates(p1_line1, p2_line1);

            var p1_line2 = CalculateRotationCoordinates(line2.Point1, line.Point1);
            var p2_line2 = CalculateRotationCoordinates(line2.Point2, line.Point1);
            line2.SetCoordinates(p1_line2, p2_line2);

            var p1_line3 = CalculateRotationCoordinates(line3.Point1, line.Point1);
            var p2_line3 = CalculateRotationCoordinates(line3.Point2, line.Point1);
            line3.SetCoordinates(p1_line3, p2_line3);
        }

        private PointF CalculateRotationCoordinates(PointF point, PointF slide)
        {
            float sin = float.Sin(10 * float.Pi / 180);
            float cos = float.Cos(10 * float.Pi / 180);

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
    }
}
