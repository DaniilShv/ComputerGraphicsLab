using ComputerGraphicsLab.Entities;
using ComputerGraphicsLab.Enums;

namespace ComputerGraphicsLab
{
    public partial class Form1 : Form
    {
        const float gradus = 10;

        PartOfShape partOfShape;

        Pen pen_gr = new Pen(Color.Green, 4);
        Pen pen_bl = new Pen(Color.Black, 4);

        float sin = float.Sin(gradus * float.Pi / 180);
        float cos = float.Cos(gradus * float.Pi / 180);

        readonly Shape shape;

        readonly Line line1;
        readonly Line line2;
        readonly Line line3;

        readonly Hook hook;

        RectangleF circle1;
        RectangleF circle2;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            label1.Text = partOfShape.ToString();
            shape = new Shape(new RectangleF(60, 150, 10, 10),
                new RectangleF(100, 150, 10, 10),
                [new PointF(60, 150), new PointF(110, 150)]);
            line1 = new Line(new PointF(85, 149),
                new PointF(85, 80));
            circle1 = new RectangleF(80, 70, 10, 10);
            line2 = new Line(new PointF(87, 70),
                new PointF(130, 50));
            circle2 = new RectangleF(128, 45, 10, 10);
            line3 = new Line(new PointF(135, 50),
                new PointF(190, 55));
            hook = new Hook(new Line(new PointF(line3.Point2.X+3, line3.Point2.Y-10), 
                new PointF(line3.Point2.X, line3.Point2.Y+13)),
                new Line(new PointF(line3.Point2.X + 3, line3.Point2.Y - 10), 
                new PointF(line3.Point2.X+26, line3.Point2.Y-8)),
                new Line(new PointF(line3.Point2.X, line3.Point2.Y + 13), 
                new PointF(line3.Point2.X + 23, line3.Point2.Y + 16)));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            shape.Draw(pen_bl, graphics);
            line1.Draw(pen_gr, graphics);
            line2.Draw(pen_gr, graphics);
            line3.Draw(pen_gr, graphics);
            hook.Draw(pen_bl, graphics);
            graphics.DrawEllipse(pen_bl, circle1);
            graphics.DrawEllipse(pen_bl, circle2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                partOfShape += 1;
                if (partOfShape > PartOfShape.Circle2)
                    partOfShape = PartOfShape.Shape;
                label1.Text = partOfShape.ToString();
                return;
            }

            if (partOfShape == PartOfShape.Shape)
                MoveShape(e);
            if (partOfShape == PartOfShape.Circle)
            {
                var p = CalculateRotationCoordinate(line2.Point2, line2.Point1);

                circle2.X = p.X-5;
                circle2.Y = p.Y-7;

                var p_line2 = CalculateRotationCoordinate(line2.Point2, line2.Point1);

                var p1_line3 = CalculateRotationCoordinate(line3.Point1, line2.Point1);
                var p2_line3 = CalculateRotationCoordinate(line3.Point2, line2.Point1);

                line2.SetCoordinates(point2: p_line2);
                line3.SetCoordinates(p1_line3, p2_line3);
                hook.MoveRelatingLine(line2);
            }
            if (partOfShape == PartOfShape.Circle2)
            {
                var p2 = CalculateRotationCoordinate(line3.Point2, line3.Point1);
                line3.SetCoordinates(point2: p2);
                hook.MoveRelatingLine(line3);
            }
            Invalidate();
        }

        private void MoveShape(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                line1.MoveShapeX(1);
                line2.MoveShapeX(1);
                line3.MoveShapeX(1);
                shape.MoveShapeX(1);
                hook.MoveShapeX(1);
                circle1.Location = new PointF(circle1.X + 1, circle1.Y);
                circle2.Location = new PointF(circle2.X + 1, circle2.Y);
            }
            if (e.KeyCode == Keys.Left)
            {
                line1.MoveShapeX(-1);
                line2.MoveShapeX(-1);
                line3.MoveShapeX(-1);
                shape.MoveShapeX(-1);
                hook.MoveShapeX(-1);
                circle1.Location = new PointF(circle1.X - 1, circle1.Y);
                circle2.Location = new PointF(circle2.X - 1, circle2.Y);
            }
            if (e.KeyCode == Keys.Up)
            {
                shape.MoveShapeY(-1);
                line1.MoveShapeY(-1);
                line2.MoveShapeY(-1);
                line3.MoveShapeY(-1);
                hook.MoveShapeY(-1);
                circle1.Location = new PointF(circle1.X, circle1.Y - 1);
                circle2.Location = new PointF(circle2.X, circle2.Y - 1);
            }
            if (e.KeyCode == Keys.Down)
            {
                shape.MoveShapeY(1);
                line1.MoveShapeY(1);
                line2.MoveShapeY(1);
                line3.MoveShapeY(1);
                hook.MoveShapeY(1);
                circle1.Location = new PointF(circle1.X, circle1.Y + 1);
                circle2.Location = new PointF(circle2.X, circle2.Y + 1);
            }
        }

        private PointF CalculateRotationCoordinate(PointF point, PointF slide)
        {
            float m = -slide.X;
            float n = -slide.Y;
            float k = -m;
            float l = -n;
            var x = point.X;
            var y = point.Y;

            float dx = x * cos - y * sin + m * cos - n * sin + k;
            float dy = x * sin + y * cos + m * sin + n * cos + l;

            return new PointF(dx, dy);
        }
    }
}
