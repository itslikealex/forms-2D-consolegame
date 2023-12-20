using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGame.csengine
{
    public class g2dvec
    {
        public float x { get; set; }
        public float y { get; set; }

        public g2dvec()
        {
            x = zero().x;
            y = zero().y;
        }

        public g2dvec(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static g2dvec zero()
        {
            return new g2dvec(0,0);
        }
    }
}
