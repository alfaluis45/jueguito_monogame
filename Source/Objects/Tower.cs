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
    internal class Tower : Enemie
    {
        Animation animado;
        public Tower(Vector2 POS) : base(POS, new Vector2(128, 128), 4, 64, 100)
        {
            animado = new Animation(new string[] { "2d\\Tower\\0", "2d\\Tower\\1" }, base.pos, base.dim, 10);
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
