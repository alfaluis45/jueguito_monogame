using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Jueguito
{
    internal class Bala : Basic2d
    {
        public int vida = 300;
        List<Enemie> target;
        public Bala(String PATH, Vector2 POS, Vector2 DIM, List<Enemie> TARGET) : base(PATH, POS, DIM)
        {
            base.pos = POS;
            base.dim = DIM;

            base.myModel = Global.content.Load<Texture2D>(PATH);
            target = TARGET;
        }

        public override void Update()
        {
            base.pos.X += 5;
            vida--;
        }
        public int EvaluarTiro()
        {
            
                for (int i = 0; i < target.Count; i++)
                {
                    Vector2 v = base.pos - target[i].pos;
                    float distance = v.X * v.X + v.Y * v.Y;
                    if (distance < target[i].hitbox * target[i].hitbox)
                    {
                        return i;
                    }
                }
                
            
            return -1;
        }
        

    }
}
