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
    internal class Knight : Enemie
    {
        Animation animado;
        public Knight(Vector2 POS) : base(POS, new Vector2(64, 64), 2, 32, 20)
        {
            animado = new Animation(new string[] { "2d\\Knight\\0", "2d\\Knight\\1", "2d\\Knight\\2",
            "2d\\Knight\\3", "2d\\Knight\\4", "2d\\Knight\\5",
            "2d\\Knight\\6", "2d\\Knight\\7", "2d\\Knight\\8",
            "2d\\Knight\\9", "2d\\Knight\\10", "2d\\Knight\\11",}, base.pos, base.dim, 4);
        }

        public override void Update()
        {
            base.pos.X -= 4;
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

