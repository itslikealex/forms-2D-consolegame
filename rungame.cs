using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupProject_3037_;
using System.Drawing;
using GroupProject_3037_.csengine;
using System.Windows.Forms;

namespace GroupProject_3037_
{
    class rungame : GroupProject_3037_.csengine.game
    {
        bool up, down, left, right;
        string[,] map =
        {
            {"S","S","S","S","S","S","S","S","S","S" },
            {"D",".",".",".",".",".",".",".",".","S"},
            {"S","T","T","T","T",".","T","T","T","S" },
            {"S",".",".",".",".",".",".",".",".","S"},
            {"S",".",".",".","T","T","T","T","T","S" },
            {"S",".",".",".",".",".",".",".",".","S" },
            {"S",".",".",".",".",".",".",".",".","S"},
            {"S","T","T","T","T","T","T","T","H","S" },
            {"S","S","S","S","S","S","S","S","S","S" }
        };
        g2dsprite playerObject;
        public rungame() : base(new g2dvec(560, 560), "3037 Game") { }

        public override void getKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up) up = true;
            if (e.KeyCode == Keys.Left) left = true;
            if (e.KeyCode == Keys.Down) down = true;
            if (e.KeyCode == Keys.Right) right = true;
        }
        public override void getKeyUp(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up) up = false;
            if (e.KeyCode == Keys.Left) left = false;
            if (e.KeyCode == Keys.Down) down = false;
            if (e.KeyCode == Keys.Right) right = false;
        }
        public override void OnDraw()
        {
            
        }
        public override void OnLoad()
        {
            Background = Color.Black;

            for (int i = 0; i < map.GetLength(1); i++)
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[j,i] == "T")
                        new g2dsprite(new g2dvec(i*56, j*56), new g2dvec(56, 56), "Grass", "worldObject_grass");
                    if (map[j, i] == "S")
                        new g2dsprite(new g2dvec(i * 56, j * 56), new g2dvec(56, 56), "Dirt", "worldObject_dirt");
                    if(map[j, i] == "H")
                        new g2dsprite(new g2dvec(i * 56, j * 56), new g2dvec(56, 56), "Spike", "worldObject_dirt");
                    if (map[j, i] == "D")
                        new g2dsprite(new g2dvec(i * 56, j * 56), new g2dvec(56, 56), "Door", "worldObject_dirt");
                }
            playerObject = new g2dsprite(new g2dvec(56,56), new g2dvec(56,56), "Mace", "playerObject");


        }
        public override void OnUpdate()
        {
            if (up)
                playerObject.position.y -= 2.0f;
            if (down)
                playerObject.position.y += 2.0f;
            if (left)
                playerObject.position.x -= 2.0f;
            if (right)
                playerObject.position.x += 2.0f;
        }
    }
}

