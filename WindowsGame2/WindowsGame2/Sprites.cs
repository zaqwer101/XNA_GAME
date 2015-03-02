using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace WindowsGame2
{
    public class Sprites
    {
        public string name;
        public Texture2D spriteTexture;
        public Vector2 spritePosition;


        public Sprites()
        {

        }

        public void LoadContent(ContentManager Content, String texture)
        {
            this.spriteTexture = Content.Load<Texture2D>(texture);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, spritePosition, Color.White);
        }

        public int LocateNear(string name) //0 - нет, 1 - справа, 2 - слева, 3 - снизу, 4 - сверху
        {
            try
            {
                if (Game1.terain1.points[Convert.ToInt32((this.spritePosition.X + 50) / 50f), Convert.ToInt32(this.spritePosition.Y / 50f)].name == name)
                    return 1;
                else
                    if (Game1.terain1.points[Convert.ToInt32((this.spritePosition.X - 50) / 50f), Convert.ToInt32(this.spritePosition.Y / 50f)].name == name)
                        return 2;
                    else
                        if (Game1.terain1.points[Convert.ToInt32((this.spritePosition.X) / 50f), Convert.ToInt32((this.spritePosition.Y + 50) / 50f)].name == name)
                            return 3;
                        else
                            if (Game1.terain1.points[Convert.ToInt32((this.spritePosition.X) / 50f), Convert.ToInt32((this.spritePosition.Y - 50) / 50f)].name == name)
                                return 4;
                            else
                                return 0;
            }
            catch
            {
                return 0;
            }
                    
        }   
    }
}