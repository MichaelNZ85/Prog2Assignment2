/* ******************************************************************************************************
 * Program name:            Pac-Man              
 * Project file name:       PacMan
 * Author:                  Michael Inglis
 * Date:                    11 November 2015
 * Language:                C#
 * Platform:                Microsoft Visual Studio 2013
 * Purpose:                 The object of this game is to build the classic arcade game Pac-Man where 
 *                          Pac-Man travels through a maze eating kibbles. There are 3 ghosts who try to 
 *                          kill Pac-Man. Pac-Man needs to eat all the kibbles before the ghosts get him.
 * Known Bugs:              None    
 * Additional Features:     
 *******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {
        //fields
        
        private const int HEIGHT = 800;
        private const int WIDTH = 600;

        private Controller controller;
        private Maze maze;
        private int theScore;

        public Form1()
        {
            InitializeComponent();

            //form properties
            Top = 0;
            Left = 0;
            Height = HEIGHT;
            Width = WIDTH;



            //create three bitmap objects and set images
            Bitmap k = new Bitmap("kibble.bmp");
            Bitmap w = new Bitmap("wall.bmp");
            Bitmap b = new Bitmap("blank.bmp");

            //create maze
            maze = new Maze(k, w, b);
           // maze.CellBorderStyle = DataGridViewCellBorderStyle.None; //got this from stack overflow


            //add maze to list of controls
            
            Controls.Add(maze);

            controller = new Controller(maze, timer1, label1);

            this.Focus();//Matt helped with this

            theScore = controller.Score;
            
            //start timer
            timer1.Enabled = true;
            
            //timer1.Enabled = false;
        }

        //timer method
        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.StartGame();
            label1.Text = "Score: " + controller.Score.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //maze.CellBorderStyle = DataGridViewCellBorderStyle.None; //got this from stack overflow

        }

        //key down event handler
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    controller.SetPacmanDirection(Direction.Left);
                    break;
                case Keys.Right:
                    controller.SetPacmanDirection(Direction.Right);
                    break;
                case Keys.Up:
                    controller.SetPacmanDirection(Direction.Up);
                    break;
                case Keys.Down:
                    controller.SetPacmanDirection(Direction.Down);
                    break;
                default:
                    break;

            }
        }

        //not used - was for button to pause game
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        //this got here by mistake
        private void label2_Click(object sender, EventArgs e)
        {

        }

        }
    }