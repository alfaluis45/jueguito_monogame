using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

namespace Jueguito
{
    internal class Queen : Enemie
    {
        Animation animado;
        public Queen(Vector2 POS) : base(POS, new Vector2(256, 256), 8, 128, 500)
        {
            animado = new Animation(new string[] { "2d\\Queen\\0", "2d\\Queen\\1", "2d\\Queen\\2",
            "2d\\Queen\\3", "2d\\Queen\\4", "2d\\Queen\\5"}, base.pos, base.dim, 5);
        }

        public override void Update()
        {
            base.pos.X -= 1;
            animado.setPos(base.pos);
            animado.Update();
            base.Update();
        }

        public override void Draw()
        {
            animado.Draw();
        }
    }
}
