using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Hero : Sprites
    {
        public List<Item> items = new List<Item>();
        public static int c = 0;
        public void ChopChop()
        {
            switch (Program.hero.LocateNear("Дерево"))
            {
                case 1:
                    for (int i = 0; i < Game1.sprites.Count; i++)
                    {
                        if (((Game1.sprites[i].spritePosition.X - 50) == Program.hero.spritePosition.X) & Program.hero.spritePosition.Y == Game1.sprites[i].spritePosition.Y)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X / 50), Convert.ToInt32(Game1.sprites[i].spritePosition.Y / 50)].CanGo = true;
                            Game1.sprites.RemoveAt(i);

                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < Game1.sprites.Count; i++)
                    {
                        if (((Game1.sprites[i].spritePosition.X + 50) == Program.hero.spritePosition.X) & Program.hero.spritePosition.Y == Game1.sprites[i].spritePosition.Y)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X / 50), Convert.ToInt32(Game1.sprites[i].spritePosition.Y / 50)].CanGo = true;
                            Game1.sprites.RemoveAt(i);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < Game1.sprites.Count; i++)
                    {
                        if (((Game1.sprites[i].spritePosition.Y - 50) == Program.hero.spritePosition.Y) & Program.hero.spritePosition.X == Game1.sprites[i].spritePosition.X)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X / 50), Convert.ToInt32(Game1.sprites[i].spritePosition.Y / 50)].CanGo = true;
                            Game1.sprites.RemoveAt(i);
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < Game1.sprites.Count; i++)
                    {
                        if (((Game1.sprites[i].spritePosition.Y + 50) == Program.hero.spritePosition.Y) & Program.hero.spritePosition.X == Game1.sprites[i].spritePosition.X)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X / 50), Convert.ToInt32(Game1.sprites[i].spritePosition.Y / 50)].CanGo = true;
                            Game1.sprites.RemoveAt(i);

                        }
                    }
                    break;
                default:
                    break;
            }

            items.Add(new Item_material("Wood",0.5f));
            items[c].name = "дерево";
            c++;
        }
    }
}
