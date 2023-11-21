using TestFN2.Business;

namespace TestFN2
{
    public partial class Form1 : Form
    {

        bool isKeyDown = false;
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
                    panel.Margin = new Padding(0);
                    tableLayoutPanel1.Controls.Add(panel, j, i);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = new Panel().BackColor;
                }
            }



            snake.moveHeadDirection();
            snake.moveTailDirection();

            Stack<Point> snakePoints = snake.returnSnakePoints();

            if (snakePoints == null)
            {
                timer1.Stop();

                MessageBox.Show("YOU LOSE");
                return;
            }

            foreach (Point point in snakePoints)
            {

                if (point.X == tableLayoutPanel1.RowCount || point.X < 0 || point.Y == tableLayoutPanel1.ColumnCount || point.Y < 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Test");
                    return;
                }
                tableLayoutPanel1.GetControlFromPosition(point.Y, point.X).BackColor = Color.Black;
            }

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isKeyDown)
                return;
            isKeyDown = true;


            if (e.KeyCode == Keys.Control) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (snake.headDirection == Directions.RIGHT) return;
                    snake.turnPoint.Add(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.LEFT, snake.tailDirection));
                    snake.headDirection = Directions.LEFT;
                    break;
                case Keys.Right:
                    if (snake.headDirection == Directions.LEFT) return;
                    snake.turnPoint.Add(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.RIGHT, snake.tailDirection));
                    snake.headDirection = Directions.RIGHT;
                    break;
                case Keys.Up:
                    if (snake.headDirection == Directions.DOWN) return;
                    snake.turnPoint.Add(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.UP, snake.tailDirection));
                    snake.headDirection = Directions.UP;
                    break;
                case Keys.Down:
                    if (snake.headDirection == Directions.UP) return;
                    snake.turnPoint.Add(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.DOWN, snake.tailDirection));
                    snake.headDirection = Directions.DOWN;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyDown = false;
        }
    }
}