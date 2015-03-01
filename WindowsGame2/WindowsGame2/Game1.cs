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
            terain1 = new Terrain1();
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hero.LoadContent(Content, "Квадрат");

        }


        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            #region Обработчик движения игрока
            // Вправо
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) & a)
                {
                    a = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X + 50) / 50f), Convert.ToInt32(hero.spritePosition.Y / 50f)].CanGo)
                    {
                        hero.spritePosition.X += 50;
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
            // Влево
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) & b)
                {
                    b = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X - 50) / 50f), Convert.ToInt32(hero.spritePosition.Y / 50f)].CanGo)
                    {
                        hero.spritePosition.X -= 50;
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
            // Вниз
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

            // Вверх
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
