using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Font DefaultFont;
        string TextInFile = "";
        public static string[] find;
        public string[] white;
        private string path = "";

        public Form1()
        {
            InitializeComponent();
            //формат открываемого файла
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*}";
            //устанавливаем стандартный шрифт и цвет для текста
            textBox1.SelectionColor = Color.Red;
            DefaultFont = textBox1.Font;
            //считываем файлы поиска слов и белый лист
            textBox1.Text = File.ReadAllText("find.txt",Encoding.Default);
            find = textBox1.Text.Split('\n');
            textBox1.Text = File.ReadAllText("white.txt",Encoding.Default);
            white = textBox1.Text.Split('\n');
            textBox1.Text = "" ;
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            path = openFileDialog1.FileName;
            // читаем файл в строку
            TextInFile = System.IO.File.ReadAllText(filename, Encoding.Default);
            textBox1.Text = TextInFile;
            textBox1.Select(0, textBox1.Text.Length);
            textBox1.SelectionColor = Color.Black;
            textBox1.SelectionFont = DefaultFont;
        }
        private void выполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //проверяем изменения в файле
            if (Healper.chek1 == 1)
            {
                find = Healper.fword;
            }
            if (Healper.chek2 == 1)
            {
                white = Healper.wlist;
            }
            //если файл открыт - мы применяем наш алгоритм в действие
            if (textBox1.Text != "")
            {
                //убираем прошлое окрашивание текста
                textBox1.Select(0, textBox1.Text.Length);
                textBox1.SelectionColor = Color.Black;
                textBox1.SelectionFont = DefaultFont;
                try
                {
                    
                    bool chek = false;
                    //выбираем слово, которое нужно найти
                    for (int i = 0; i < find.Length; i++)
                    {

                        int startIndex = 0;
                        bool c = false;
                        //сверяем слово с белым листом
                        for (int j = 0; j < white.Length; j++)
                        {
                            if (white[j] == find[i])
                            {
                                c = true;
                            }
                        }
                        //проверяем есть ли текст в файла, который мы ищем
                        if (textBox1.Text.Contains(find[i]) && c == false)
                        {
                            int index = -1;
                            int selectStart = textBox1.SelectionStart;
                            while ((index = textBox1.Text.IndexOf(find[i], (index + 1))) != -1)
                            {

                                //меняем шрифт и цвет найденого текста
                                textBox1.Select((index + startIndex), find[i].Length);
                                textBox1.SelectionFont = new Font("Comic Sans MS", 16); ;
                                textBox1.SelectionColor = Color.Red;
                            }
                            chek = true;
                        }
                        //если слова в тексте нет
                        else
                        {
                            chek = false;

                        }

                    }
                    if (chek = false) MessageBox.Show("В файле нет такого сочитания букв");

                    if (chek = true) MessageBox.Show(" Слова выделены большим регистром и красным цветом");
                }
                catch (Exception)
                {
                }
            }//если файл не открыт - программа выдаёт сообщение о том, что нам нужно открыть файл
            else
            {
                MessageBox.Show("Вы не открыли файл");
            }
        }
        //открывает список слов для поиска
        private void словаДляПоискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Healper.fword = find;
            Form2 fform = new Form2();
            fform.Show();
            
        }
        //открывает белый список
        private void белыйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Healper.wlist = white;
            Form3 fform = new Form3();
            fform.Show();
        }
        //сохраняет файл
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //если файл не был открыт до этого, то предлагает сохранить в какое-нибудь место
            if (path == "")
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, textBox1.Text, Encoding.Default);
            }
            else//перезаписывает файл
            {
                File.WriteAllText(path, textBox1.Text, Encoding.Default);
            }
            
        }
        //сохраняет файл в какое-нибудь место
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text, Encoding.Default);
        }
        //открывает тестовый файл
        private void тестовыйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText("test.txt", Encoding.Default);
        }
    }
}
