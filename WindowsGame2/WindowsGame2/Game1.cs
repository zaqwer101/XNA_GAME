using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace WindowsGame2
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public bool a = true, b = true, c = true, d = true;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprites hero;
        Terrain1 terain1;
        public Game1()
        {
            terain1 = new Terrain1("Grass");
            
            hero = new Sprites();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;    // 800 на 600, каждый спрайт 50х50
            graphics.PreferredBackBufferHeight = 600;
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            terain1.TFill();
            terain1.TLoadTexture(Content);
            terain1.points[5, 5].LoadContent(Content, "GrassWithRock");
            terain1.points[5, 5].CanGo = false;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hero.LoadContent(Content, "–ыц¬лево");
           
        }


        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            #region ќбработчик движени€ игрока
            // ¬право
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) & a)
                {
                    a = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X + 50) / 50f), Convert.ToInt32(hero.spritePosition.Y / 50f)].CanGo)
                    {
                        hero.spritePosition.X += 50;
                        hero.spriteTexture = Content.Load<Texture2D>("–ыц¬право");
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    a = true;
                    
                }
            }
            catch
            {

            }
            // ¬лево
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) & b)
                {
                    b = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X - 50) / 50f), Convert.ToInt32(hero.spritePosition.Y / 50f)].CanGo)
                    {
                        hero.spritePosition.X -= 50;
                        hero.spriteTexture = Content.Load<Texture2D>("–ыц¬лево");
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Left))
                {
                    b = true;
                }
            }
            catch
            {

            }
            // ¬низ
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down) & c)
                {
                    c = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X / 50f)), Convert.ToInt32((hero.spritePosition.Y + 50) / 50f)].CanGo)
                    {
                        hero.spritePosition.Y += 50;
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Down))
                {
                    c = true;
                }
            }
            catch
            {

            }

            // ¬верх
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) & d)
                {
                    d = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X / 50f)), Convert.ToInt32((hero.spritePosition.Y - 50) / 50f)].CanGo)
                    {
                        hero.spritePosition.Y -= 50;
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Up))
                {
                    d = true;
                }
            }
            catch
            {

            }
            #endregion



            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            terain1.TDraw(spriteBatch);
            hero.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
