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
    internal class Robot
    {
        public Vector2 pos, dim;
        public bool shot = false;
        public Animation walk;
        public Animation walk_shot;

        public Robot(Vector2 POS, Vector2 DIM)
        {
            pos = POS;
            dim = DIM;

            walk = new Animation(new string[] { "2d\\Robot\\Walk\\0", "2d\\Robot\\Walk\\1" }, pos,
                dim, 10);
            walk_shot = new Animation(new string[] { "2d\\Robot\\WalkShot\\0", "2d\\Robot\\WalkShot\\1",
            "2d\\Robot\\WalkShot\\2", "2d\\Robot\\WalkShot\\3",
            "2d\\Robot\\WalkShot\\4", "2d\\Robot\\WalkShot\\5"}, pos,
                dim, 10);
        }

        public void setShot(bool b)
        {
            shot = b;
            
        }

        public void setPos(Vector2 POS)
        {
            pos = POS;
        }

        public void Update()
        {
            
            walk.setPos(pos);
            walk_shot.setPos(pos);
            walk.Update();
            walk_shot.Update();
            
        }

        public void Draw()
        {
            if (shot)
            {
                walk_shot.Draw();
            }
            else
            {
                walk.Draw();
            }
        }

    }
}
