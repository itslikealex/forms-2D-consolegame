using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupProject_3037_;
using System.Drawing;
using GroupProject_3037_.csengine;

namespace GroupProject_3037_
{
    class rungame : GroupProject_3037_.csengine.game
    {

        string[,] map =
        {
            {".",".",".",".",".",".",".",".",".","." },
            {"T","T","T","T","T",".","T","T","T","T" },
            {".",".",".",".",".",".",".","." ,".","."},
            {".",".",".",".","T","T","T","T","T","T" },
            {".",".",".",".",".",".",".",".",".","." },
            {".",".",".",".",".",".",".","." ,".","."},
            {"T","T","T","T","T","T","T","T","T","T" },
            {"S","S","S","S","S","S","S","S","S","S" }
        };
        g2dsprite playerObject;
        public rungame() : base(new g2dvec(560, 560), "3037 Game") { }

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
                }
            playerObject = new g2dsprite(new g2dvec(1,1), new g2dvec(56,56), "Mace", "playerObject");


        }

        float x = 0.01f;
        int time = 0;
        public override void OnUpdate()
        {
            if (time > 400)
            {
                if(playerObject != null)
                {
                    playerObject.selfdestroy();
                    playerObject = null;
                }
            }
            
            
            

        }
    }
}

