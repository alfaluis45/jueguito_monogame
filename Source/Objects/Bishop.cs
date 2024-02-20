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
    internal class Bishop : Enemie
    {
        Animation animado;
        public Bishop(Vector2 POS) : base(POS, new Vector2(64, 64), 2, 32, 20)
        {
            animado = new Animation(new string[] { "2d\\Bishop\\0", "2d\\Bishop\\1", "2d\\Bishop\\2",
            "2d\\Bishop\\3"}, base.pos, base.dim, 10);
        }

        public override void Update()
        {
            base.pos.X -= 2;
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
