namespace ComputerGraphicsLab.Entities
{
    public class Hook : Shape
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

        public override void Draw(Pen pen, Graphics graphics)
        {
            line1.Draw(pen, graphics);
            line2.Draw(pen, graphics);
            line3.Draw(pen, graphics);
        }

        public override void MoveShape(float x = 0, float y = 0)
        {
            line1.MoveShape(x,y);
            line2.MoveShape(x,y);
            line3.MoveShape(x,y);
        }

        public void MoveRelatingPoint(PointF slide, float gradus)
        {
            line1.RotateLine(slide, gradus);

            line2.RotateLine(slide, gradus);

            line3.RotateLine(slide, gradus);
        }

        public bool LimitXRight(int x)
        {
            return line1.LimitXRight(x) && line2.LimitXRight(x) && line3.LimitXRight(x);
        }
        public bool LimitXLeft(int x)
        {
            return line1.LimitXLeft(x) && line2.LimitXLeft(x) && line3.LimitXLeft(x);
        }
    }
}
