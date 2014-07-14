using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace TZFE
{
    public partial class Form1 : Form
    {
        //  CheckChangeTextbox1, CheckChangeTextbox2; - строки с проверкой изменения текстбоксов;
        int score;
        public Random rnd = new Random();
        public TextBox[,] array_TextBoxes = new TextBox[4, 4];
        public Fill_textboxes fill = new Fill_textboxes();
        public Key_down key_press = new Key_down();
        public string CheckChangeTextbox1 , CheckChangeTextbox2 ;
        public bool winner = false;

        // Объявляем переменную, которая включает режим перетаскивания
        private bool bDragStatus;
        // Хранит координаты смещения при щелчке мышью
        private Point clickPoint;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameBegin();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (winner)
                return;
            // Передаем нажатие в метод Нажатия_кнопки
            score = key_press.Key_press(array_TextBoxes, (char)e.KeyValue, score);

            if (score >= int.Parse(label4.Text))
                label4.Text = score.ToString();

            foreach (TextBox tb in array_TextBoxes)
            {
                if (tb.Text == "2048")
                {
                    DialogResult DR = MessageBox.Show("Вы выиграли! Начать заново?", "", MessageBoxButtons.YesNo);
                    if (DR == System.Windows.Forms.DialogResult.Yes)
                        GameBegin();
                    else
                        winner = true;
                }
            }
            loose();
            CheckChangeTextbox2 = StringTB();

            if (CheckChangeTextbox2 == CheckChangeTextbox1)
                return;

            if ((e.KeyValue == (char)Keys.Left) || (e.KeyValue == (char)Keys.Right)
                || (e.KeyValue == (char)Keys.Up) || (e.KeyValue == (char)Keys.Down))
                fill.Fill_random(array_TextBoxes);

                CheckChangeTextbox1 = StringTB();
                label2.Text = score.ToString();
                Colors();
        }
        public void GameBegin()
        {
            winner = false;
            score = 0;
            label2.Text = "0";

            if (int.Parse(label4.Text.ToString()) < score)
            { label4.Text = score.ToString(); }
            //Заполняем массив текстбоксов
            array_TextBoxes[0, 0] = textBox1;
            array_TextBoxes[0, 1] = textBox2;
            array_TextBoxes[0, 2] = textBox3;
            array_TextBoxes[0, 3] = textBox4;
            array_TextBoxes[1, 0] = textBox5;
            array_TextBoxes[1, 1] = textBox6;
            array_TextBoxes[1, 2] = textBox7;
            array_TextBoxes[1, 3] = textBox8;
            array_TextBoxes[2, 0] = textBox9;
            array_TextBoxes[2, 1] = textBox10;
            array_TextBoxes[2, 2] = textBox11;
            array_TextBoxes[2, 3] = textBox12;
            array_TextBoxes[3, 0] = textBox13;
            array_TextBoxes[3, 1] = textBox14;
            array_TextBoxes[3, 2] = textBox15;
            array_TextBoxes[3, 3] = textBox16;
            
            foreach (TextBox tb in array_TextBoxes)
            {
                tb.Text = "";
                tb.BackColor = Color.White;
            }

           fill.Fill_random(array_TextBoxes);
           fill.Fill_random(array_TextBoxes);
           
            Colors();
            CheckChangeTextbox1 = StringTB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameBegin();
        }
        public void Colors()
        {
            //Меняем цвет ячеек  и размер текста
            foreach (TextBox tb in array_TextBoxes)
            {
                PictureBox pb = TextboxToPicture(tb);
                if (tb.Text == "2")
                {
                    pb.Image = TZFE.Properties.Resources._2;
                    pb.BackColor = Color.LightGray;
                }
                else if (tb.Text == "4")
                {
                   pb.Image = TZFE.Properties.Resources._4;
                   pb.BackColor = Color.Red;
                }
                else if (tb.Text == "8")
                {
                    pb.Image = TZFE.Properties.Resources._8;
                    pb.BackColor = Color.Orange;
                }
                else if (tb.Text == "16")
                {
                   pb.Image = TZFE.Properties.Resources._16;
                   pb.BackColor = Color.Yellow;
                }
                else if (tb.Text == "32")
                {
                   pb.Image = TZFE.Properties.Resources._32;
                   pb.BackColor = Color.Green;
                }
                else if (tb.Text == "64")
                {
                    pb.Image = TZFE.Properties.Resources._64;
                    pb.BackColor = Color.Blue;
                }
                else if (tb.Text == "128")
                {
                   pb.Image = TZFE.Properties.Resources._128;
                   pb.BackColor = Color.DarkBlue;
                }
                else if (tb.Text == "256")
                {
                   pb.Image = TZFE.Properties.Resources._256;
                   pb.BackColor = Color.Purple;
                }
                else if (tb.Text == "512")
                {
                    pb.Image = TZFE.Properties.Resources._512;
                    pb.BackColor = Color.MediumPurple;
                }
                else if (tb.Text == "1024")
                {
                   pb.Image = TZFE.Properties.Resources._1024;
                   pb.BackColor = Color.RoyalBlue;
                }
                else if (tb.Text == "2048")
                {
                    pb.Image = TZFE.Properties.Resources._2048;
                    pb.BackColor = Color.Aqua;
                }
                else
                {
                    pb.Image = null;
                    pb.BackColor = Color.White;
                }
            }
        }

        public string StringTB()
        {
           string str = "";
           foreach (TextBox tb in array_TextBoxes)
            {
                if (tb.Text != "")
                
                    str += tb.Text;
                
                else
                    str += " ";
           }
           return str;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GameBegin();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Включаем режим перетаскивания
                // и сохраняем координаты мыши
                bDragStatus = true;
                clickPoint = new Point(e.X, e.Y);
            }
            else
            {
                bDragStatus = false;
            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDragStatus)
            {
                Point pointMoveTo;
                // Получим текущие координаты мыши в экранных координатах
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                // Изменяем позицию на величину clickPoint
                pointMoveTo.Offset(-clickPoint.X, -clickPoint.Y);
                // Перемещаем форму
                this.Location = pointMoveTo;
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            // Отключаем режим перетаскивания
            bDragStatus = false;
        }
        //Метод нахождения проигрыша 
        public void loose()
        {
            bool space = false ;
            bool end = false;
            foreach(TextBox tb in array_TextBoxes)
            {
                if (tb.Text == "")
                    space = true;
            }
            for(int i =0;i < 3;i++)
                for (int o = 0; o < 3; o++)
                {
                    if (array_TextBoxes[i, o].Text == array_TextBoxes[i + 1, o].Text || array_TextBoxes[i, o].Text == array_TextBoxes[i, o + 1].Text ||
                    array_TextBoxes[3, o].Text == array_TextBoxes[3, o + 1].Text || array_TextBoxes[i, 3].Text == array_TextBoxes[i + 1, 3].Text)
                        end = true;
                }
            if (!space && !end)
            {
                DialogResult DR = MessageBox.Show("Вы проиграли! Начать заново?","",MessageBoxButtons.YesNo);
                if (DR == System.Windows.Forms.DialogResult.Yes)
                    GameBegin();
            }
        }
        public PictureBox TextboxToPicture(TextBox tb)
        {
            if (tb.Name == "textBox1")
                return pictureBox5;
            else if (tb.Name == "textBox2")
                return pictureBox6;
            else if (tb.Name == "textBox3")
                return pictureBox7;
            else if (tb.Name == "textBox4")
                return pictureBox8;
            else if (tb.Name == "textBox5")
                return pictureBox9;
            else if (tb.Name == "textBox6")
                return pictureBox10;
            else if (tb.Name == "textBox7")
                return pictureBox11;
            else if (tb.Name == "textBox8")
                return pictureBox12;
            else if (tb.Name == "textBox9")
                return pictureBox13;
            else if (tb.Name == "textBox10")
                return pictureBox14;
            else if (tb.Name == "textBox11")
                return pictureBox15;
            else if (tb.Name == "textBox12")
                return pictureBox16;
            else if (tb.Name == "textBox13")
                return pictureBox17;
            else if (tb.Name == "textBox14")
                return pictureBox18;
            else if (tb.Name == "textBox15")
                return pictureBox19;
            else  
                return pictureBox20;

        }
    }
}
