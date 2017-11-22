/*
 * Player class - abstract class used to create subclasses Pacman and Ghost
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
    public abstract class Player
    {
        //fields
        private Bitmap picture;

        private Point position;

        protected Maze maze;
        //protected int size;

        //constructor
        public Player(String fileName, Maze maze)
        {
            picture = new Bitmap(fileName);
            this.maze = maze;
        }

        public DataGridViewCell GetGridCellForPosition(Point p)
        {
            return maze.Rows[p.Y].Cells[p.X]; 
        }

        public abstract void Draw();
        public abstract void Move();


        public Bitmap Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
