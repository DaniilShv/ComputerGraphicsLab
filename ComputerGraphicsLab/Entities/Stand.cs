namespace ComputerGraphicsLab.Entities
{
    public class Stand : Shape
    {
        RectangleF circle1;
        RectangleF circle2;
        Line line;

        public Stand(RectangleF circle1, RectangleF circle2, Line line)
        {
            this.circle1 = circle1;
            this.circle2 = circle2;
            this.line = line;
        }

        public override void Draw(Pen pen, Graphics graphics)
        {
            graphics.DrawEllipse(pen, circle1);
            graphics.DrawEllipse(pen, circle2);
            line.Draw(pen, graphics);
        }

        public override void MoveShape(float x = 0, float y = 0)
        {
            circle1.X += x;
            circle2.X += x;
            circle1.Y += y;
            circle2.Y += y;
            line.MoveShape(x, y);
        }

        public bool LimitXRight(int x)
        {
            return line.LimitXRight(x);
        }
        public bool LimitXLeft(int x)
        {
            return line.LimitXLeft(x);
        }
    }
}
