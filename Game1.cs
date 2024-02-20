


using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jueguito
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D pasto;

        private World world;
        public Vector2 mov;
        private Robot robot;
        private Song musica;
        private SoundEffect efectoDisparo;
        private List<Bala>  balas;
        private List<Enemie> enemigos;
        private int c = 0;
        private int d = 0;
        private Random random;
        private bool gameover = false;
        SpriteFont font;
        SpriteFont font1;
        private int puntaje = 0;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.content = this.Content;
            Global.spriteBatch = this._spriteBatch;
            Global.movi = this.mov;
            balas = new List<Bala>();
            enemigos = new List<Enemie>();
            random = new Random();
            font = Content.Load<SpriteFont>("Fonts/myFont");
            font1 = Content.Load<SpriteFont>("Fonts/mayor");
            // TODO: use this.Content to load your game content here
            pasto = Content.Load<Texture2D>("pasto");
            world = new World();
            robot = new Robot( new Vector2(300, 300), new Vector2(64, 64));
            musica = Content.Load<Song>("fondo");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(musica);
            efectoDisparo = Content.Load<SoundEffect>("shoot");
            efectoDisparo.Play(1.0f, 0.0f, 0.0f);
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (!gameover)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                robot.setShot(false);
                mov = Vector2.Zero;
                if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    mov.X -= 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    mov.X += 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    mov.Y += 1;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    mov.Y -= 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    if (c <= 0)
                    {

                        efectoDisparo.Play();
                        balas.Add(new Bala("2d\\bala", robot.pos, new Vector2(8, 8), enemigos));
                        c = 15;
                    }
                    robot.setShot(true);

                }
                if (c > 0)
                {
                    c--;
                }
                if (mov != Vector2.Zero)
                {
                    mov.Normalize();
                }
                robot.setPos(robot.pos + mov * 3);
                // TODO: Add your update logic here
                world.Update();
                robot.Update();
                for (int i = 0; i < balas.Count; i++)
                {
                    balas[i].Update();

                    if (balas[i].vida <= 0)
                    {
                        balas.RemoveAt(i);
                    }

                }
                if (d == 0)
                {
                    generarEnemigos();
                }
                d++;
                d = d % 300;
                for (int i = 0; i < enemigos.Count; i++)
                {
                    enemigos[i].Update();
                    if (enemigos[i].tiempo <= 0)
                    {
                        enemigos.RemoveAt(i);
                    }

                }

                for (int i = 0; i < balas.Count; i++)
                {
                    int n = balas[i].EvaluarTiro();
                    if (n >= 0)
                    {
                        enemigos[n].life = enemigos[n].life - 1;
                        if (enemigos[n].life <= 0)
                        {
                            puntaje += enemigos[n].puntos;
                            enemigos.RemoveAt(n);
                        }
                        balas.RemoveAt(i);
                    }
                }
                posBordes();
                EvaluarGolpe();
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    Restart();
                }
            }
            

            base.Update(gameTime);
            
        }
        public void Restart()
        {
            balas = new List<Bala>();
            enemigos = new List<Enemie>();
            // TODO: use this.Content to load your game content here
            world = new World();
            robot = new Robot(new Vector2(300, 300), new Vector2(64, 64));
            puntaje = 0;
            c = 0;
            d = 0;
            gameover = false;
        }

        public void posBordes()
        {
            if(robot.pos.X < 32)
            {
                robot.pos.X = 32;
            }
            if (robot.pos.Y < 32)
            {
                robot.pos.Y = 32;
            }
            if (robot.pos.X > GraphicsDevice.Viewport.Width - 32)
            {
                robot.pos.X = GraphicsDevice.Viewport.Width - 32;
            }
            if (robot.pos.Y > GraphicsDevice.Viewport.Height  - 32)
            {
                robot.pos.Y = GraphicsDevice.Viewport.Height - 32;
            }
        }

        public void generarEnemigos()
        {
            int num = (int)(random.NextDouble() * 10) + 10;
            for(int i = 0; i < num; i++)
            {
                int x = (int) (200 * random.NextDouble());
                double y = random.NextDouble();
                if(y < 0.05)
                {
                    enemigos.Add(new Queen(new Vector2(1000 + x, (int)(GraphicsDevice.Viewport.Height * random.NextDouble()))));
                }else if (y < 0.15)
                {
                    enemigos.Add(new Tower(new Vector2(1000 + x, (int)(GraphicsDevice.Viewport.Height * random.NextDouble()))));
                }else if (y < 0.35)
                {
                    enemigos.Add(new Bishop(new Vector2(1000 + x, (int)(GraphicsDevice.Viewport.Height * random.NextDouble()))));
                }
                else if (y < 0.55)
                {
                    enemigos.Add(new Knight(new Vector2(1000 + x, (int)(GraphicsDevice.Viewport.Height * random.NextDouble()))));
                }
                else
                {
                    enemigos.Add(new Pawn(new Vector2(1000 + x, (int)(GraphicsDevice.Viewport.Height * random.NextDouble()))));
                }




            }
        }

        public void EvaluarGolpe()
        {

            for (int i = 0; i < enemigos.Count; i++)
            {
                Vector2 v = robot.pos - enemigos[i].pos;
                float distance = v.X * v.X + v.Y * v.Y;
                if (distance < enemigos[i].hitbox * enemigos[i].hitbox)
                {
                    gameover = true;
                }
            }

        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            Global.spriteBatch.Begin();
            
                Global.spriteBatch.Draw(pasto, new Vector2(0, 0), Color.White);
                robot.Draw();
                for (int i = 0; i < balas.Count; i++)
                {
                    balas[i].Draw();
                }
                for (int i = 0; i < enemigos.Count; i++)
                {
                    enemigos[i].Draw();
                }
                Global.spriteBatch.DrawString(font, "Puntuacion: " + puntaje, new Vector2(0, 0), Color.Yellow);
            if (gameover)
            {
                Global.spriteBatch.DrawString(font1, "Game Over", new Vector2(175, 150), Color.Red);
                Global.spriteBatch.DrawString(font, "Press R to Restart", new Vector2(195, 280), Color.Red);
            }

            Global.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}