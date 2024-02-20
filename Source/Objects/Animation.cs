using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DXGI;

namespace Jueguito
{
    internal class Animation
    {
        public Vector2 pos, dim;

        public Texture2D [] frames;
        public int delay = 1;
        public int frame = 0;
        public int c = 0;

        public Animation(String[] PATHS, Vector2 POS, Vector2 DIM, int Del)
        {
            pos = POS;
            dim = DIM;
            frames = new Texture2D[PATHS.Length];
            for (int i = 0; i < PATHS.Length; i++)
            {
                frames[i] = Global.content.Load<Texture2D>(PATHS[i]);
            }
            if(Del > 0){
                delay = Del;
            }
            
        }

        public void setPos(Vector2 POS)
        {
            pos = POS;
        }

        public virtual void Update()
        {
            c = c + 1;
            c = c % delay;
            if(c == 0)
            {
                frame++;
                frame = frame % frames.Length;
            }
        }

        public virtual void Draw()
        {
            if (frames[frame] != null)
            {
                Global.spriteBatch.Draw(frames[frame], new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y),
                    null, Color.White, 0.0f, new Vector2(frames[frame].Bounds.Width / 2, frames[frame].Bounds.Height / 2),
                    new SpriteEffects(), 0);
            }

        }
    }
}
