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

namespace WindowsGame2
{
    public class Terrain1
    {

        string texture;
        public Terrain1(string texture)
        {
            this.texture = texture;
        }

        public TPoint[,] points = new TPoint[17,13];
        public  void TFill()
        {
            int ii=0, ff=0;
            for (int i=0;i<800;i+=50)
            {
                for(int f=0;f<600;f+=50)
                {
                    this.points[ii,ff] = new TPoint();
                    this.points[ii,ff].spritePosition = new Vector2(i, f);
                    ff++;
                }
                ff = 0;
                ii++;
            }
        }

        public void TDraw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int f = 0; f < 12; f++)
                {
                    this.points[i, f].Draw(spriteBatch);
                }
            }
        }

        public void TLoadTexture(ContentManager Content)
        {
            for (int i = 0; i < 16; i++)
            {
                for (int f = 0; f < 12; f++)
                {
                    this.points[i, f].LoadContent(Content, this.texture);
                }
            }
        }
    }
}
