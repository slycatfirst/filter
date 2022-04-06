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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //выгружает слова для поиска в окно
        private void Form2_Load(object sender, EventArgs e)
        {
            Healper.fword = textBox1.Text.Split('\n');
            for (int i = 0; i < Healper.fword.Length; i++)
            {
                textBox1.Text = textBox1.Text + Healper.fword[i] + "\n";
            }
            textBox1.Text = File.ReadAllText("find.txt", Encoding.Default);
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        class findword
        {
    }
        //сохраняет файл поиска слов
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("find.txt", textBox1.Text, Encoding.Default);
            Healper.chek1 = 1;
            Healper.fword = textBox1.Text.Split('\n');
        }
        //сохраняет файл поиска слов и закрывает окно
        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("find.txt", textBox1.Text, Encoding.Default);
            Healper.chek1 = 1;
            Healper.fword = textBox1.Text.Split('\n');
            this.Close();

        }
    }
}
