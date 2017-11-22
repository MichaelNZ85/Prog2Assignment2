/*
 * Pacman class - holds information and methods for Pac-man. A subclass of Player.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PacMan
{
    public class Pacman : Player
    {
        private const int STARTPOSITION = 11;
        private const int GRIDSIZE = 20;
        
        //fields
        private bool alive;
        private Direction direction;
        private Point nextPosition;

        private int score;

        private Bitmap secondImage;
        private SoundPlayer player;
               
        //constructor
        public Pacman(string fileName1, string fileName2, Maze maze)
            :base(fileName1, maze)
        {
            Picture = new Bitmap(fileName1);
            secondImage = new Bitmap(fileName2);
            alive = true;
            Position = new Point(STARTPOSITION, STARTPOSITION);
            direction = Direction.Right;
            player = new SoundPlayer("chomp3.wav");//sound came from http://www.classicgaming.cc/classics/pacman/sounds.php
        }

        //draws Pacman on maze
        public override void Draw()
        {
            GetGridCellForPosition(Position).Value = Picture;
        }

        //moves Pacman around
        public override void Move() //Joy helped with this
        {
            nextPosition = Position;
            
            switch (direction)
            {
                case Direction.Up:
                    nextPosition.Y--;
                   
                    break;
                case Direction.Right:
                    nextPosition.X ++;
                    break;
                case Direction.Down:
                    nextPosition.Y ++;
                    break;
                case Direction.Left:
                    nextPosition.X--;
                    break;
                default:
                    break;
            }

            
            int mazePosition = nextPosition.Y * GRIDSIZE + nextPosition.X;
            //if next square is blank then move
            if (maze.MazeMap.Substring(mazePosition, 1) == "b")
                    { 
                        Position = nextPosition;
                    }
            //if next square is kibble then move and eat kibble
            if (maze.MazeMap.Substring((mazePosition),1) == "k")
            {
                Position = nextPosition;
                score++;
                maze.MazeMap = maze.MazeMap.Substring(0, mazePosition) + "b" + maze.MazeMap.Substring(mazePosition + 1);
                player.Play();
            }

        }

       //makes Pacman's mouth open and close
        public void Animate() // Matt helped with this
        {
            //swap images
            Bitmap temp = Picture;
            Picture = secondImage;
            secondImage = temp;
        }

        /*public void GetKilled(Ghost ghost)
        {
            if (ghost.Position == position)
        }*/

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }


        public Point NextPosition
        {
            get { return nextPosition; }
            set { nextPosition = value; }
        }
        
    }
}
