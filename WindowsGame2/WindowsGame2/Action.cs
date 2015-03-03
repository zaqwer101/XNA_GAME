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
using System.Windows.Forms;

namespace WindowsGame2
{
    public partial class Action : Form
    {
        public Action()
        {
            InitializeComponent();
            if (Program.hero.LocateNear("Дерево") != 0)
            {
                button1.Show();
                button1.Text = "Срубить дерево";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(Program.hero.LocateNear("Дерево"))
            {
                case 1:
                    for (int i=0;i<Game1.sprites.Count;i++)
                    {
                        if (((Game1.sprites[i].spritePosition.X - 50) == Program.hero.spritePosition.X) & Program.hero.spritePosition.Y == Game1.sprites[i].spritePosition.Y)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X/50),Convert.ToInt32(Game1.sprites[i].spritePosition.Y/50)].CanGo = true;
                            Game1.sprites.RemoveAt(i); Close();

                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < Game1.sprites.Count; i++)
                    {
                        if (((Game1.sprites[i].spritePosition.X + 50) == Program.hero.spritePosition.X) & Program.hero.spritePosition.Y == Game1.sprites[i].spritePosition.Y)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X / 50), Convert.ToInt32(Game1.sprites[i].spritePosition.Y / 50)].CanGo = true;
                            Game1.sprites.RemoveAt(i); Close();
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < Game1.sprites.Count; i++)
                    {
                        if (((Game1.sprites[i].spritePosition.Y - 50) == Program.hero.spritePosition.Y) & Program.hero.spritePosition.X == Game1.sprites[i].spritePosition.X)
                        {
                            Game1.terain1.points[Convert.ToInt32(Game1.sprites[i].spritePosition.X / 50), Convert.ToInt32(Game1.sprites[i].spritePosition.Y / 50)].CanGo = true;
                            Game1.sprites.RemoveAt(i); Close();
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
                            Close();
                        }
                    }
                    break;
                default:
                    
                    break;
                    


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void Action_Load(object sender, EventArgs e)
        {

        }
    }
}
