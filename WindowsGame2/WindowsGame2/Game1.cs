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
        public bool right = true, left = true, down = true, up = true, TAB = true;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Sprites hero;
        public static Terrain1 terain1;
        public static List<Sprites> sprites = new List<Sprites>();
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
            Random rnd = new Random();
            int z = rnd.Next(20)+10;
            for (int i = 0; i < z;i++)
            {
                sprites.Add(new Sprites());
                sprites[i].LoadContent(Content, "Tree1");
                int x = rnd.Next(16);
                int y = rnd.Next(12);
                for (int f = 0; f < sprites.Count;f++)
                {
                    if((x == sprites[i].spritePosition.X & y==sprites[i].spritePosition.Y) || (x==0 & y==0) )
                    {
                        x = rnd.Next(16);
                        y = rnd.Next(12);
                    }
                }
                sprites[i].spritePosition = new Vector2(x * 50, y * 50);
                terain1.points[x, y].CanGo = false;
                terain1.points[x, y].name = "ƒерево";
            }
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
                if (Keyboard.GetState().IsKeyDown(Keys.Right) & right)
                {
                    right = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X + 50) / 50f), Convert.ToInt32(hero.spritePosition.Y / 50f)].CanGo)
                    {
                        hero.spritePosition.X += 50;
                        hero.spriteTexture = Content.Load<Texture2D>("–ыц¬право");
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    right = true;
                }
            }
            catch
            {

            }
            // ¬лево
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) & left)
                {
                    left = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X - 50) / 50f), Convert.ToInt32(hero.spritePosition.Y / 50f)].CanGo)
                    {
                        hero.spritePosition.X -= 50;
                        hero.spriteTexture = Content.Load<Texture2D>("–ыц¬лево");
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Left))
                {
                    left = true;
                }
            }
            catch
            {

            }
            // ¬низ
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down) & down)
                {
                    down = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X / 50f)), Convert.ToInt32((hero.spritePosition.Y + 50) / 50f)].CanGo)
                    {
                        hero.spritePosition.Y += 50;
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Down))
                {
                    down = true;
                }
            }
            catch
            {

            }

            // ¬верх
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) & up)
                {
                    up = false;
                    if (terain1.points[Convert.ToInt32((hero.spritePosition.X / 50f)), Convert.ToInt32((hero.spritePosition.Y - 50) / 50f)].CanGo)
                    {
                        hero.spritePosition.Y -= 50;
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Up))
                {
                    up = true;
                }
            }
            catch
            {

            }

            // »нвентарь

            if (Keyboard.GetState().IsKeyDown(Keys.Tab) & TAB)
            {
                TAB = false;
                //DO SMTH
                Action act = new Action();
                act.ShowDialog();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Tab))
            {
                TAB = true;
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
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
