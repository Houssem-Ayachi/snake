namespace Snake
{
    public partial class Form1 : Form
    {
        private Settings settings = new Settings();
        private Snake snake = new();
        private Apple apple = new();
        private UI ui;

        private int WIDTH;
        private int HEIGHT;

        private short score = 0;
        private short scoreAddValue = 1;

        private bool isPlaying = false;

        public Form1()
        {
            InitializeComponent();
            this.timer1.Interval = 100;

            ui = new(this.scoreLabel);

            this.WIDTH = this.canvas.Width;
            this.HEIGHT = this.canvas.Height;
        }

        private void startGame()
        {
            this.isPlaying= true;
            this.score = 0;
            this.settings.currentDirection = Settings.Directions.right;
            this.ui.DisplayScore(this.score);
            snake.clear();
            snake.addBodyPart(0, 1);
            snake.addBodyPart(0, 0);
            apple.GenerateAppleCoords(20, this.snake.bodyParts);// 20 is number of rows (calculated manually) too lazy to implement it
            this.timer1.Start();
        }

        private void terminateGame()
        {
            this.timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            (int, int) headPos = this.snake.getPosition();
            //check if head is out of bounds teleport to opposite direction
            if(headPos.Item1 < 0)
            {
                this.snake.bodyParts[0].x = 19;
            }
            else if(headPos.Item1 > 19)
            {
                this.snake.bodyParts[0].x = -1;
            }
            else if(headPos.Item2 < 0)
            {
                this.snake.bodyParts[0].y = 19;
            }
            else if(headPos.Item2 > 19)
            {
                this.snake.bodyParts[0].y = -1;
            }

            //check collisions with apples
            if(headPos.Item1 == apple.x && headPos.Item2 == apple.y)
            {
                this.snake.addLast();
                this.apple.GenerateAppleCoords(20, this.snake.bodyParts);
                this.score += this.scoreAddValue;
                ui.DisplayScore(score);
            }

            if (this.snake.isCollidingWithSelf())
            {
                terminateGame();
                MessageBox.Show("you lost :(");
                return;
            }


            //calculating which direction to move
            int stepx = 0, stepy = 0;
            switch (settings.currentDirection)
            {
                case Settings.Directions.up:
                    stepx = 0;
                    stepy = -1;
                    break;
                case Settings.Directions.down:
                    stepx = 0;
                    stepy = 1;
                    break;
                case Settings.Directions.left:
                    stepx = -1;
                    stepy = 0;
                    break;
                case Settings.Directions.right:
                    stepx = 1;
                    stepy = 0;
                    break;
            }
            snake.updateBodyPartsPosition(stepx, stepy);

            this.canvas.Invalidate();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (!this.isPlaying) return;
            //updating the direction to the corresponding key pressed if possible
            switch(e.KeyCode){
                case Keys.Z:
                    settings.UpdateDirection(Settings.Directions.up);
                    break;
                case Keys.S:
                    settings.UpdateDirection(Settings.Directions.down);
                    break;
                case Keys.Q:
                    settings.UpdateDirection(Settings.Directions.left);
                    break;                
                case Keys.D:
                    settings.UpdateDirection(Settings.Directions.right);
                    break;            
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (!this.isPlaying) return;
            Graphics canvas = e.Graphics;
            //draw snake body parts on canvas   
            foreach(SnakeBodyPart bodyPart in this.snake.bodyParts)
            {
                canvas.FillEllipse(Brushes.Green, bodyPart.x * settings.step, bodyPart.y * settings.step, bodyPart.width, bodyPart.height);
            }

            //draw apple on canvas
            canvas.FillEllipse(Brushes.Red, apple.x * settings.step, apple.y * settings.step, 30, 30);

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startGame();
            
        }
    }

}