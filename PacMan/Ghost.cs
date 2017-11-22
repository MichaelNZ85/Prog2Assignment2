/*
 * Ghost class - holds information and methods for a ghost. A subclass of Player.
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
    public class Ghost : Player
    {
        private const int GRIDSIZE = 20;

        //fields
        private Direction direction;
        private Bitmap secondImage;
        private Point nextPosition;
        private Random random;
        private int hitWall;

        //constructor
        public Ghost(string fileName1, string filename2, Maze maze, Point position)
            : base(fileName1, maze)
        {
            this.Position = position;
            Picture = new Bitmap(fileName1);
            secondImage = new Bitmap(filename2);
            random = new Random();
        }

        public override void Draw()
        {
            GetGridCellForPosition(Position).Value = Picture;
        }

        public override void Move()
        {
            nextPosition = Position;

            switch (direction)
            {
                case Direction.Up:
                    nextPosition.Y--;
                    break;
                case Direction.Right:
                    nextPosition.X++;
                    break;
                case Direction.Down:
                    nextPosition.Y++;
                    break;
                case Direction.Left:
                    nextPosition.X--;
                    break;
                default:
                    break;
            }

            int mazePosition = nextPosition.Y * GRIDSIZE + nextPosition.X;
            if (maze.MazeMap.Substring(mazePosition, 1) == "b")
            {
                Position = nextPosition;
            }

            if (maze.MazeMap.Substring(mazePosition, 1) == "k")
            {
                Position = nextPosition;
            }

            if (maze.MazeMap.Substring(mazePosition, 1) == "w")
            {
                hitWall = random.Next(4);
                switch (hitWall)
                {
                    case 0:
                        direction = Direction.Up;
                        break;
                    case 1:
                        direction = Direction.Left;
                        break;
                    case 2:
                        direction = Direction.Down;
                        break;
                    case 3:
                        direction = Direction.Right;
                        break;
                }
            }
        }
                
        public void Animate() // Matt helped with this
        {
            //swap images
            Bitmap temp = Picture;
            Picture = secondImage;
            secondImage = temp;
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Point NextPosition
        {
            get { return nextPosition; }
            set { nextPosition = value; }
        }
    }
}
