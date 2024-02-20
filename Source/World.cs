using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;

namespace Jueguito
{
    internal class World
    {
        public Basic2d hero;
        public Basic2d [] fondo;
        
        public World() { 
            hero = new Basic2d("2d\\Bishop",new Vector2(200,200), new Vector2(64, 64));
            fondo = new Basic2d [12];
            for (int i = 0; i < fondo.Length; i++)
            {
                fondo[i] = new Basic2d("2d\\Background\\background", new Vector2(112 + 225 * (i % 4), 112 + 225 * (i / 4)),
                    new Vector2(225, 225));
            }
            
        }

        public virtual void Update()
        {
            
            
            hero.Update();
            
            
        }



        public virtual  void Draw()
        {
            hero.Draw();
            for (int i = 0; i < fondo.Length; i++)
            {
                fondo[i].Draw();
            }
           
        }

    }
}
