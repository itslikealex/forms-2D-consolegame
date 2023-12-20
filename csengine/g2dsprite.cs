using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormsGame.csengine
{
    internal class g2dsprite
    {
        public g2dvec position;
        public g2dvec scale;
        public string tag = "";
        public string directory = "";
        public Bitmap sprite = null;


        public g2dsprite(g2dvec position, g2dvec scale, string directory, string tag)
        {
            this.position = position;
            this.scale = scale;
            this.directory = directory;
            this.tag = tag;

            Image image = Image.FromFile($"Assets/Sprites/{directory}.png");
            sprite = new Bitmap(image, (int)this.scale.x, (int)this.scale.y);
            

            consoleLog.info($"[INFO] {tag} registered");
            game.registerSprite(this);

        }
        public void selfdestroy()
        {
            game.unregisterSprite(this);
        }
    }
}
