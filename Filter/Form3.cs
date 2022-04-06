using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //выгружает белый лист в окно
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("white.txt", textBox1.Text, Encoding.Default);
            Healper.chek2 = 1;
            Healper.wlist = textBox1.Text.Split('\n');
        }
        //сохраняет файл поиска слов
        private void Form3_Load(object sender, EventArgs e)
        {
            Healper.fword = textBox1.Text.Split('\n');
            for (int i = 0; i < Healper.fword.Length; i++)
            {
                textBox1.Text = textBox1.Text + Healper.fword[i] + "\n";
            }
            textBox1.Text = File.ReadAllText("white.txt", Encoding.Default);
        }
        //сохраняет файл поиска слов и закрывает окно
        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("white.txt", textBox1.Text, Encoding.Default);
            Healper.chek2 = 1;
            Healper.wlist = textBox1.Text.Split('\n');
            this.Close();
        }
    }
}
