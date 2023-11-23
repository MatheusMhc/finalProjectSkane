using System.Drawing;
using TestFN2.Business;
using static System.Net.Mime.MediaTypeNames;

namespace TestFN2
{
    public partial class Form1 : Form
    {

        bool isKeyDown = false;
        int score = 0;
        Menu menu;
        int interval;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Menu menu, int interval)
        {
            this.menu = menu;
            this.interval = interval;
            InitializeComponent();
            lblDoYouContinue.Visible = false;
            lblYes.Visible = false;
            lblNo.Visible = false;
            menu.loadingProgress.Visible = true;
            timeTic.Interval = interval;
            loadPanelOnGrid(ref menu.loadingProgress);

            menu.Hide();
        }

        public Form1(Form1 form, int interval)
        {
            this.interval = interval;
            InitializeComponent();
            lblDoYouContinue.Visible = false;
            lblYes.Visible = false;
            lblNo.Visible = false;
            form.loadProgressGame.Visible = true;
            timeTic.Interval = interval;
            loadPanelOnGrid(ref form.loadProgressGame);

            form.Hide();

        }

        Snake snake = new Snake();
        Food food = new Food();

        private void loadPanelOnGrid(ref ProgressBar barProgress)
        {
            for (int i = 0; i < tableGridGameSkane.RowCount; i++)
            {
                for (int j = 0; j < tableGridGameSkane.ColumnCount; j++)
                {
                    Panel panel = new Panel();
                    panel.Margin = new Padding(0);
                    tableGridGameSkane.Controls.Add(panel, j, i);
                }
                barProgress.PerformStep();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < tableGridGameSkane.RowCount; i++)
            {
                for (int j = 0; j < tableGridGameSkane.ColumnCount; j++)
                {
                    tableGridGameSkane.GetControlFromPosition(j, i).BackColor = new Panel().BackColor;
                }
            }

            do
            {
                food.createRandomFood(tableGridGameSkane.RowCount, tableGridGameSkane.ColumnCount, snake.returnSnakePoints());
            } while (!food.created);


            snake.moveHeadDirection();
            snake.moveTailDirection();

            Stack<Point> snakePoints = snake.returnSnakePoints();

            if (snake.wasIBitten())
            {
                timeTic.Stop();
                tableGridGameSkane.Visible = false;
                painelWall.Visible = false;
                grpBoxScore.Visible = false;
                picBoxYouDied.Visible = true;
                lblDoYouContinue.Visible = true;
                lblYes.Visible = true;
                lblNo.Visible = true;

                return;
            }


            if (food.wasEaten(snake.returnSnakePoints()))
            {
                snake.increaseMySize();
                score = score + 1;
                lblScoreValue.Text = score.ToString();
                food.created = false;
            }

            foreach (Point point in snakePoints)
            {

                if (point.X == tableGridGameSkane.RowCount || point.X < 0 || point.Y == tableGridGameSkane.ColumnCount || point.Y < 0)
                {

                    timeTic.Stop();
                    tableGridGameSkane.Visible = false;
                    painelWall.Visible = false;
                    grpBoxScore.Visible = false;
                    picBoxYouDied.Visible = true;
                    lblDoYouContinue.Visible = true;
                    lblYes.Visible = true;
                    lblNo.Visible = true;

                    return;
                }

                tableGridGameSkane.GetControlFromPosition(point.Y, point.X).BackColor = Color.Black;
            }
            tableGridGameSkane.GetControlFromPosition(food.point.Y, food.point.X).BackColor = Color.Blue;
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
                    snake.addTurnPointIfNotExist(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.LEFT, snake.tailDirection));
                    snake.headDirection = Directions.LEFT;
                    break;
                case Keys.Right:
                    if (snake.headDirection == Directions.LEFT) return;
                    snake.addTurnPointIfNotExist(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.RIGHT, snake.tailDirection));
                    snake.headDirection = Directions.RIGHT;
                    break;
                case Keys.Up:
                    if (snake.headDirection == Directions.DOWN) return;
                    snake.addTurnPointIfNotExist(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.UP, snake.tailDirection));
                    snake.headDirection = Directions.UP;
                    break;
                case Keys.Down:
                    if (snake.headDirection == Directions.UP) return;
                    snake.addTurnPointIfNotExist(new TurnPoint(new Point(snake.head.X, snake.head.Y), Directions.DOWN, snake.tailDirection));
                    snake.headDirection = Directions.DOWN;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyDown = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // I got this code from here https://itecnote.com/tecnote/c-set-panel-border-thickness-in-c-winform/ and it worked
            int thickness = 3;
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(Color.Black, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          painelWall.ClientSize.Width - thickness,
                                                          painelWall.ClientSize.Height - thickness));
            }
        }

        private void lblYes_Click(object sender, EventArgs e)
        {
            var form1 = new Form1(this, this.interval);
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void lblNo_Click(object sender, EventArgs e)
        {

            var menu = new Menu();
            this.Close();
            menu.Show();
        }
    }
}