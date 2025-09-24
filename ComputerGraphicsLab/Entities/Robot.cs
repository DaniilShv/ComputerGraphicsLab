using ComputerGraphicsLab.Enums;

namespace ComputerGraphicsLab.Entities
{
    public class Robot
    {
        readonly Stand shape;

        readonly Line line1;
        readonly Line line2;
        readonly Line line3;

        readonly Hook hook;

        RectangleF circle1;
        RectangleF circle2;

        readonly Pen pen;
        readonly Pen penLine;

        public int LimXRight { get; set; } = 10000;
        public int LimXLeft { get; set; } = 0;

        public Robot(float x, float y, Pen pen, Pen penLine)
        {
            shape = new Stand(new RectangleF(60, 150, 10, 10),
                new RectangleF(100, 150, 10, 10),
                new Line(new PointF(60, 150), new PointF(110, 150)));
            line1 = new Line(new PointF(85, 149),
                new PointF(85, 80));
            circle1 = new RectangleF(80, 70, 10, 10);
            line2 = new Line(new PointF(87, 70),
                new PointF(130, 50));
            circle2 = new RectangleF(line2.Point2.X - 4, line2.Point2.Y - 6, 10, 10);
            line3 = new Line(new PointF(135, 50),
                new PointF(190, 55));
            hook = new Hook(new Line(new PointF(line3.Point2.X + 3, line3.Point2.Y - 10),
                new PointF(line3.Point2.X, line3.Point2.Y + 13)),
                new Line(new PointF(line3.Point2.X + 3, line3.Point2.Y - 10),
                new PointF(line3.Point2.X + 26, line3.Point2.Y - 8)),
                new Line(new PointF(line3.Point2.X, line3.Point2.Y + 13),
                new PointF(line3.Point2.X + 23, line3.Point2.Y + 16)));

            MoveShape(x, y);
            this.pen = pen;
            this.penLine = penLine;
        }

        public void Draw(Graphics graphics)
        {
            shape.Draw(pen, graphics);
            line1.Draw(penLine, graphics);
            line2.Draw(penLine, graphics);
            line3.Draw(penLine, graphics);
            hook.Draw(pen, graphics);
            graphics.DrawEllipse(pen, circle1);
            graphics.DrawEllipse(pen, circle2);
            graphics.FillEllipse(pen.Brush, circle1);
            graphics.FillEllipse(pen.Brush, circle2);
        }

        public void MoveShape(float x = 0, float y = 0)
        {
            if (!LimitXRight(LimXRight) && x > 0)
                return;
            if (!LimitXLeft(LimXLeft) && x < 0)
                return;
            line1.MoveShape(x, y);
            line2.MoveShape(x, y);
            line3.MoveShape(x, y);
            shape.MoveShape(x, y);
            hook.MoveShape(x, y);
            circle1.Location = new PointF(circle1.X + x, circle1.Y + y);
            circle2.Location = new PointF(circle2.X + x, circle2.Y + y);
        }

        public void Rotation(RotationAxis axis, float gradus)
        {
            if (axis == RotationAxis.First)
            {
                var p = Shape.CalculateRotationCoordinate(line2.Point2, line2.Point1, gradus);

                circle2.X = p.X - 4;
                circle2.Y = p.Y - 6;

                line2.RotatePoint2(circle1.Location, gradus);
                line3.RotateLine(circle1.Location, gradus);
                hook.MoveRelatingPoint(circle1.Location, gradus);
            }
            if (axis == RotationAxis.Second)
            {
                line3.RotatePoint2(line3.Point1, gradus);
                hook.MoveRelatingPoint(line3.Point1, gradus);
            }
        }

        public bool LimitXRight(int x)
        {
            return line1.LimitXRight(x) && line2.LimitXRight(x) && line3.LimitXRight(x)
                && hook.LimitXRight(x) && shape.LimitXRight(x);
        }

        public bool LimitXLeft(int x)
        {
            return line1.LimitXLeft(x) && line2.LimitXLeft(x) && line3.LimitXLeft(x)
                && hook.LimitXLeft(x) && shape.LimitXLeft(x);
        }

        public void Scale(float scale, PartOfStick partOfStick)
        {
            switch (partOfStick)
            {
                case PartOfStick.FirstStick:
                    line1.SetCoordinates(point2: new PointF(line1.Point2.X, line1.Point2.Y - scale));
                    line2.MoveShape(y: -scale);
                    line3.MoveShape(y: -scale);
                    circle1.Y -= scale;
                    circle2.Y -= scale;
                    hook.MoveShape(y: -scale);
                    break;
                case PartOfStick.SecondStick:
                    line3.SetCoordinates(point2:Shape.ScalePoint(line3.Point2, line3.Point1, scale));
                    hook.Scale(scale);
                    break;
            }
        }
    }
}
