using TestFN2.Business;

namespace TestFN2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Skane snake = new Skane();

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    Panel panel = new Panel();
                    tableLayoutPanel1.Controls.Add(panel, j, i);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point a = snake.head;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = new Panel().BackColor;
                }
            }


            if (snake.headDirection == Directions.RIGHT)
            {
                snake.turnPoint.Add(new Point(snake.head.X, snake.head.Y));
                Point point = new Point(snake.head.X, snake.head.Y + 1);
                Point point2 = new Point(snake.tail.X, snake.tail.Y + 1);
                snake.headDirection = Directions.RIGHT;
                snake.head = point;
                snake.tail = point2;
            }

            if (snake.headDirection == Directions.DOWN)
            {
                snake.turnPoint.Add(new Point(snake.head.X, snake.head.Y));
                Point point = new Point(snake.head.X + 1, snake.head.Y);
                Point point2 = new Point(snake.tail.X + 1, snake.tail.Y);
                snake.headDirection = Directions.DOWN;
                snake.head = point;
                snake.tail = point2;
            }
            if (snake.headDirection == Directions.LEFT)
            {
                snake.turnPoint.Add(new Point(snake.head.X, snake.head.Y));
                Point point = new Point(snake.head.X, snake.head.Y - 1);
                Point point2 = new Point(snake.tail.X, snake.tail.Y - 1);
                snake.headDirection = Directions.LEFT;
                snake.head = point;
                snake.tail = point2;
            }
            if (snake.headDirection == Directions.UP)
            {
                snake.turnPoint.Add(new Point(snake.head.X, snake.head.Y));
                Point point = new Point(snake.head.X - 1, snake.head.Y);
                Point point2 = new Point(snake.tail.X - 1, snake.tail.Y);
                snake.headDirection = Directions.UP;
                snake.head = point;
                snake.tail = point2;
            }

            Stack<Point> snakePoints = snake.returnSnakePoints();

            foreach (Point point in snakePoints)
            {
                tableLayoutPanel1.GetControlFromPosition(point.Y, point.X).BackColor = Color.Black;
            }
            /*for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    tableLayoutPanel1.GetControlFromPosition(a.Y, a.X).BackColor = Color.Black;
                }
            }*/
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Control) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    snake.headDirection = Directions.LEFT;
                    break;
                case Keys.Right:
                    snake.headDirection = Directions.RIGHT;
                    break;
                case Keys.Up:
                    snake.headDirection = Directions.UP;
                    break;
                case Keys.Down:
                    snake.headDirection = Directions.DOWN;
                    break;
            }
        }
    }
}