/*
 * Controller class - used to manage the game.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public class Controller
    {
        private const int NUMBEROFKIBBLES = 193;
        private const int NUMBEROFGHOSTS = 3;
        private const int GHOST0X = 9;
        private const int GHOST0Y = 9;
        private const int GHOST1X = 10;
        private const int GHOST1Y = 9;
        private const int GHOST2X = 11;
        private const int GHOST2Y = 9;

        //fields
        private bool GameOver;
        private Pacman pacman;
        private Ghost[] ghosts;
        private Maze maze;
        private Timer timer;
        private int score;

        //constructor
        public Controller(Maze maze, Timer timer, Label label)
        {
            this.maze = maze;
            this.timer = timer;
            pacman = new Pacman("pacman1.bmp", "pacman2.bmp", maze);
            pacman.Alive = true;
            ghosts = new Ghost[NUMBEROFGHOSTS];
            ghosts[0] = new Ghost("red1.bmp", "red2.bmp", maze, new Point(GHOST0X, GHOST0Y));
            ghosts[0].Direction = Direction.Up;
            ghosts[1] = new Ghost("green1.bmp", "green2.bmp", maze, new Point(GHOST1X, GHOST1Y));
            ghosts[1].Direction = Direction.Left;
            ghosts[2] = new Ghost("orange1.bmp", "orange2.bmp", maze, new Point(GHOST2X, GHOST2Y));
            ghosts[2].Direction = Direction.Right;
            score = pacman.Score;
           // label.Text = score.ToString();
            
        }

        //sets Pac-man's direction
        public void SetPacmanDirection(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    pacman.Direction = Direction.Up;
                    break;
                case Direction.Right:
                    pacman.Direction = Direction.Right;
                    break;
                case Direction.Down:
                    pacman.Direction = Direction.Down;
                    break;
                case Direction.Left:
                    pacman.Direction = Direction.Left;
                    break;
                default:
                    break;
            }
        }

        public void CheckForGameOver()
        {
            for (int i = 0; i < ghosts.Length; i++)
            {
                if (pacman.Position == ghosts[i].Position)
                {
                    timer.Enabled = false;
                    MessageBox.Show("Pac-Man got eaten by a ghost!");
                    MessageBox.Show("Game Over!");
                }
                
                //if (((pacman.Direction == Direction.Left) && (ghosts[i].Direction == Direction.Right)) ||
                //    ((pacman.Direction == Direction.Right) && (ghosts[i].Direction == Direction.Left)) ||
                //    ((pacman.Direction == Direction.Up) && (ghosts[i].Direction == Direction.Down)) ||
                //    ((pacman.Direction == Direction.Down) && (ghosts[i].Direction == Direction.Up)))
                //{
                //    if (pacman.Position == ghosts[i].NextPosition)
                //    {
                //        timer.Enabled = false;
                //        MessageBox.Show("Pac-Man got eaten by a ghost!");
                //        MessageBox.Show("Game Over!");
                //    }
                //}
                               
            }
        }

        public void CheckForWin()
        {
            if (score ==  NUMBEROFKIBBLES)
            {
                timer.Enabled = false;
                MessageBox.Show("You win!");
            }
        }
        

        //method to start the game - calls other methods
        public void StartGame()
        {
            maze.DrawMaze();
            pacman.Move();
            score = pacman.Score;
            

            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].Move();
            }
            pacman.Draw();
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].Draw();
            }
            pacman.Animate();
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].Animate();
            }
            CheckForGameOver();
            CheckForWin();

                       
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

    
    }

   
}