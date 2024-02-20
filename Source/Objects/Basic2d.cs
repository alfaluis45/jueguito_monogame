using System;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jueguito
{
    public class Basic2d
    {
        public Vector2 pos, dim;

        public Texture2D myModel;

        public  Basic2d(String PATH, Vector2 POS, Vector2 DIM)
        {
            pos = POS;
            dim = DIM;

            myModel = Global.content.Load<Texture2D>(PATH);
        }

        public virtual void setPos(Vector2 POS)
        {
            pos = POS;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            if (myModel != null)
            {
                Global.spriteBatch.Draw(myModel, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y),
                    null, Color.White, 0.0f, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height / 2),
                    new SpriteEffects(), 0);
            }
            
        }
    }
}
