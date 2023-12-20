using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FormsGame.csengine
{
    public class g2dshape
    {
        public g2dvec position = null;
        public g2dvec scale = null;
        public string Tag = "";

        public g2dshape(g2dvec position, g2dvec scale, string Tag)
        {
            this.position = position;
            this.scale = scale;
            this.Tag = Tag;
            
            consoleLog.info($"[{Tag}]_this shape was registered. . .");
            game.registerShapes(this);

        }

        public object Scale { get; internal set; }

        public void selfdestroy()
        {
            consoleLog.info($"[{Tag}]_this shape was destroyed. . .");
            game.unregisterShapes(this);
        }
     }
}
