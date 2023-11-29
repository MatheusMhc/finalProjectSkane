using System.Drawing;
using System.Media;
using System.Reflection;
using SnakeGameSpace.Business;
using NAudio.Wave;
using System.Xml.Linq;

namespace SnakeGameSpace
{
    public partial class Game : Form
    {
        /*Do not allow press two buttons at the same time*/
        bool isKeyDown = false;

        int score = 0;
        /* Previous Menu Screen */
        Menu menu;

        /*interval Timer Level Game*/
        int interval;

        WaveOut soundPlayer = new WaveOut();

        Snake snake = new Snake();

        Food food = new Food();
        
        /*FILO queue to control sequence of moviments*/
        Queue<BendPoint> queueChanges = new Queue<BendPoint>();

        public Game()
        {
            InitializeComponent();
        }

        public Game(Menu menu, int interval)
        {
            selectSoundGame("../../../resources/game.wav");
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

        public Game(Game form, int interval)
        {
            selectSoundGame("../../../resources/game.wav");
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

        private void selectSoundGame(string name)
        {
            AudioFileReader sound = new AudioFileReader(name);
            soundPlayer.Init(sound);
            soundPlayer.Play();
        }

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

        private void youDied()
        {
            soundPlayer.Dispose();
            timeTic.Stop();
            soundPlayer = new WaveOut();
            selectSoundGame("../../../resources/youdied.wav");
            tableGridGameSkane.Visible = false;
            painelWall.Visible = false;
            grpBoxScore.Visible = false;
            picBoxYouDied.Visible = true;
            lblDoYouContinue.Visible = true;
            lblYes.Visible = true;
            lblNo.Visible = true;
        }

        private void cleanGrid()
        {
            for (int i = 0; i < tableGridGameSkane.RowCount; i++)
            {
                for (int j = 0; j < tableGridGameSkane.ColumnCount; j++)
                {
                    tableGridGameSkane.GetControlFromPosition(j, i).BackColor = new Panel().BackColor;
                }
            }
        }

        private void creteFood()
        {
            do
            {
                food.createRandomFood(tableGridGameSkane.RowCount, tableGridGameSkane.ColumnCount, snake.returnSnakePoints());
            } while (!food.created);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            cleanGrid();
            BendPoint bendPoints = new BendPoint();

            /*Get the next moviment*/
            if (queueChanges.Count != 0)
            {
                bendPoints = queueChanges.Dequeue();
                snake.addBendPointIfNotExist(bendPoints);
                snake.headDirection = bendPoints.headDirection;
            }

            creteFood();

            snake.moveHeadDirection();
            snake.moveTailDirection();

            Stack<Point> snakePoints = snake.returnSnakePoints();

            if (snake.wasIBitten())
            {
                youDied();
                return;
            }

            if (food.wasEaten(snakePoints))
            {
                selectSoundGame("../../../resources/eatdood.wav");
                snake.increaseMySize();
                score = ++score;
                lblScoreValue.Text = score.ToString();
                food.created = false;
            }

            if (snake.didIHitTheWall(tableGridGameSkane.RowCount, tableGridGameSkane.ColumnCount))
            {
                youDied();
                return;
            }


            foreach (Point point in snakePoints)
            {
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
                    if (snake.headDirection == Directions.RIGHT || snake.headDirection == Directions.LEFT) return;
                    queueChanges.Enqueue(new BendPoint(new Point(snake.head.X, snake.head.Y), Directions.LEFT, snake.tailDirection));
                    break;
                case Keys.Right:
                    if (snake.headDirection == Directions.LEFT || snake.headDirection == Directions.RIGHT) return;
                    queueChanges.Enqueue(new BendPoint(new Point(snake.head.X, snake.head.Y), Directions.RIGHT, snake.tailDirection));
                    break;
                case Keys.Up:
                    if (snake.headDirection == Directions.DOWN || snake.headDirection == Directions.UP) return;
                    queueChanges.Enqueue(new BendPoint(new Point(snake.head.X, snake.head.Y), Directions.UP, snake.tailDirection));
                    break;
                case Keys.Down:
                    if (snake.headDirection == Directions.UP || snake.headDirection == Directions.DOWN) return;
                    queueChanges.Enqueue(new BendPoint(new Point(snake.head.X, snake.head.Y), Directions.DOWN, snake.tailDirection));
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
            soundPlayer.Dispose();
            var form1 = new Game(this, this.interval);
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void lblNo_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}