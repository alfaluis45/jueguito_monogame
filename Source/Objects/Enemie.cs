using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Jueguito
{
    public class Enemie
    {
        public Vector2 pos, dim;

        public int tiempo = 1000;

        public int life, hitbox;
        public int puntos;
        public Enemie( Vector2 POS, Vector2 DIM, int LIFE, int HITBOX, int PUNTOS)
        {
            pos = POS;
            dim = DIM;
            life = LIFE;
            hitbox = HITBOX;
            puntos = PUNTOS;
        }

        public virtual void Update() {
            tiempo--;
        }

        public virtual void Draw()
        {

        }
    }
}
