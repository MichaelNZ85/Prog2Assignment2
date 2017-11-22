/*
 * Maze Class = used to create the maze where Pac-man and the ghosts will be placed
 * NOTE: Much of the code in this class comes from Joy's MazeDemo program. This was a great help in building the program.
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
    public class Maze : DataGridView
    {
        //constants
        private const int MAZESIZE = 20;
        private const int SIZEOFCELL = 30;
        private const int SIZEOFSPACE = 4;
        private const int NUMBEROFKIBBLES = 193;

        private const string INITIALMAP = "wwwwwwwwwwwwwwwwwwww" +
                                    /*2*/"wkkkkkkkkkkkkkkkkkkw" +
                                    /*3*/"wkwwwwkwwwkwwwkwwwkw" +
                                    /*4*/"wkkkkkkwwwkwwwkwwwkw" +
                                        "wkwwkwkkkkkkkkkwkwkw" +
                                        "wkkkkkkwwwwwwkwwkwkw" +
                                        "wkwkwkkkkkkkkkwkkkkw" +
                                        "wkwkwkwbbbbbwkwkwwkw" +
                                        "wkwkkkwbbbbbwkkkwwkw" +
                                        "wkwkwkwbbbbbwwkkwkkw" +
                                        "wkwkkkwwwwwwwwwkwwkw" +
                                        "wkkkwkkkkkkkkkkkkkkw" +
                                        "wkwkwwwwkwwwwwkwkwkw" +
                                        "wkwkkkkkkkkkkwkwkwkw" +
                                        "wkwwkkwkwwwkwkkwkwkw" +
                                        "wkwkkkwkkkkkkkwkkkkw" +
                                        "wkwkwkkkkwkkwkkkwwkw" +
                                        "wkwkwwwwwwkkwwwwwkkw" +
                                        "wkkkkkkkkkkkkkkkkkkw" +
                                        "wwwwwwwwwwwwwwwwwwww";
        //fields
        private String mazeMap;
       private int numberOfKibbles;
        private Bitmap wall;
        private Bitmap kibble;
        private Bitmap blank;

        //constructor
        public Maze(Bitmap k, Bitmap w, Bitmap b)
            :base()
        {
            mazeMap = INITIALMAP;
            wall = w;
            kibble = k;
            blank = b;
            numberOfKibbles = NUMBEROFKIBBLES;

            //set maze's position
            Top = 0;
            Left = 0;

            //set up columns for images
            for (int i = 0; i < MAZESIZE; i++)
            {
                Columns.Add(new DataGridViewImageColumn());
            }
            //set number of rows
            RowCount = MAZESIZE;
            ScrollBars = ScrollBars.None;
            Height = MAZESIZE * SIZEOFCELL + SIZEOFSPACE;
            Width = MAZESIZE * SIZEOFCELL + SIZEOFSPACE;
            ColumnHeadersVisible = false;
            RowHeadersVisible = false;

            //set cell size
            foreach (DataGridViewRow r in this.Rows)
            {
                r.Height = SIZEOFCELL;
            }

            foreach (DataGridViewColumn c in this.Columns)
            {
                c.Width = SIZEOFCELL;
            }

            //turn off automatic resizing
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            CellBorderStyle = DataGridViewCellBorderStyle.None; //got this from stack overflow

            //turn off user resizing
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
        }

        //DrawMaze method - draws maze on screen
        public void DrawMaze()
        {
            int totalNumberOfCells = MAZESIZE * MAZESIZE;

            for (int i = 0; i < totalNumberOfCells; i++)
            {
                int numRow = i / MAZESIZE;
                int numCol = i % MAZESIZE;

                switch (mazeMap.Substring(i, 1))
                {
                    case "w":
                        Rows[numRow].Cells[numCol].Value = wall;
                        break;
                    case "k":
                        Rows[numRow].Cells[numCol].Value = kibble;
                        break;
                    case "b":
                        Rows[numRow].Cells[numCol].Value = blank;
                        break;
                    default:
                        MessageBox.Show("Unknown value");
                        break;

                }
            }
        }

        //MazeMap property
        public String MazeMap
        {
            get { return mazeMap; }
            set { mazeMap = value; }
        }

    }
}
