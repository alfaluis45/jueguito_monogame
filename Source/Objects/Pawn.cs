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
    internal class Pawn : Enemie
    {
        Animation animado;
        public Pawn(Vector2 POS) : base(POS, new Vector2(64, 64), 1, 32, 10)
        {
            animado = new Animation(new string[] {"2d\\Pawn\\0", "2d\\Pawn\\1", "2d\\Pawn\\2" }, base.pos, base.dim, 10);
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
