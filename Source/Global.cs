
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.MediaFoundation;

namespace Jueguito
{
    class Global
    {
        public static ContentManager content;

        public static SpriteBatch spriteBatch;

        public static float  vel = 2.0f;
        
        public static Vector2 movi;
    }
}
