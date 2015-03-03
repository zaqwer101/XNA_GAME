using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsGame2
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.Items.RemoveAt(i);
            }
            int a=0;
            for(int i=0;i<Program.hero.items.Count;i++)
            {
                    listBox1.Items.Add(Program.hero.items[i].name);
                    a++;
            }
            label1.Text = "Вес: " + (0.5f * a);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "Это " + listBox1.Items[listBox1.SelectedIndex] + "\nЗАПИХАЙ ЕГО СЕБЕ В ЖОПУ!";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
