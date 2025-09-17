namespace ComputerGraphicsLab.Entities
{
    public class Shape
    {
        RectangleF circle1;
        RectangleF circle2;
        PointF[] line;

        public Shape(RectangleF circle1, RectangleF circle2, PointF[] line)
        {
            this.circle1 = circle1;
            this.circle2 = circle2;
            this.line = line;
        }

        public void Draw(Pen pen, Graphics graphics)
        {
            graphics.DrawEllipse(pen, circle1);
            graphics.DrawEllipse(pen, circle2);
            graphics.DrawLine(pen, line[0], line[1]);
        }

        public void MoveShapeX(int dx)
        {
            circle1.X += dx;
            circle2.X += dx;
            for (int i = 0; i < line.Length; i++)
            {
                line[i].X += dx;
            }
        }
        public void MoveShapeY(int dy)
        {
            circle1.Y += dy;
            circle2.Y += dy;
            for (int i = 0; i < line.Length; i++)
            {
                line[i].Y += dy;
            }
        }
    }
}
