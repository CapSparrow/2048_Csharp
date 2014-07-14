using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TZFE
{
    public class Key_down
    {
        //Метод обработки надатия клавиш
        public int Key_press(TextBox[,] array_Textboxes, char key_down, int score)
        {
            int value;
            switch (key_down)
            {
                case (char)Keys.Down:
                    {
                        for (int o = 0; o < 4; o++)
                        for (int i = 2; i >=0; i--)
                            {
                                //Проверка непустого значения
                                if (array_Textboxes[i, o].Text != "")
                                {
                                    value = i;
                                    while (value +1 <= 3)
                                    {
                                        if (array_Textboxes[value + 1, o].Text == "")
                                        {
                                            array_Textboxes[value + 1, o].Text = array_Textboxes[value, o].Text;
                                            array_Textboxes[value, o].Text = "";
                                            value++;
                                        }
                                        else if (array_Textboxes[value + 1, o].Text == array_Textboxes[value, o].Text)
                                        {
                                            array_Textboxes[value + 1, o].Text = (2* int.Parse(array_Textboxes[value, o].Text)).ToString();
                                            array_Textboxes[value, o].Text = "";
                                            score += int.Parse(array_Textboxes[value + 1, o].Text);
                                        }
                                        else
                                            break;
                                    }
                                }
                            }
                                break;
                    }
                case (char)Keys.Up:
                    {
                        for (int o = 3; o >= 0; o--)
                        for (int i = 1; i <= 3; i++)
                            {
                                //Проверка непустого значения
                                if (array_Textboxes[i, o].Text != "")
                                {
                                    value = i;
                                    while (value - 1 >=0)
                                    {
                                        if (array_Textboxes[value - 1, o].Text == "")
                                        {
                                            array_Textboxes[value - 1, o].Text = array_Textboxes[value, o].Text;
                                            array_Textboxes[value, o].Text = "";
                                            value--;

                                        }
                                        else if (array_Textboxes[value - 1, o].Text == array_Textboxes[value, o].Text)
                                        {
                                            array_Textboxes[value - 1, o].Text = (2 * int.Parse(array_Textboxes[value - 1, o].Text)).ToString();
                                            score += int.Parse(array_Textboxes[value - 1, o].Text);
                                            array_Textboxes[value, o].Text = "";

                                        }
                                        else 
                                            break;
                                    }
                                }
                            }
                                break;
                    }
                case (char)Keys.Right:
                    {
                        for (int i = 0; i <4; i++)
                            for (int o = 2; o >=0; o--)
                            {
                                //Проверка непустого значения
                                if (array_Textboxes[i, o].Text != "")
                                {
                                    value = o;
                                    while (value + 1 <= 3)
                                    {
                                        if (array_Textboxes[i, value + 1].Text == "")
                                        {
                                            array_Textboxes[i, value + 1].Text = array_Textboxes[i, value].Text;
                                            array_Textboxes[i, value].Text = "";
                                            value++;

                                        }
                                        else if (array_Textboxes[i, value + 1].Text == array_Textboxes[i, value].Text)
                                        {
                                            array_Textboxes[i, value + 1].Text = (2 * int.Parse(array_Textboxes[i, value + 1].Text)).ToString();
                                            score += int.Parse(array_Textboxes[i, value + 1].Text);
                                            array_Textboxes[i, value].Text = "";
                                        }
                                        else
                                            break;
                                    }
                                }
                            }
                        break;
                    }
                case (char)Keys.Left:
                    {
                        for (int i = 0; i < 4; i++)
                            for (int o = 1; o <=3; o++)
                            {
                                //Проверка непустого значения
                                if (array_Textboxes[i, o].Text != "")
                                {
                                    value = o;
                                    while (value - 1 >=0)
                                    {
                                        if (array_Textboxes[i, value - 1].Text == "")
                                        {
                                            array_Textboxes[i, value - 1].Text = array_Textboxes[i, value].Text;
                                            array_Textboxes[i, value].Text = "";
                                            value--;
                                        }
                                        else if (array_Textboxes[i, value - 1].Text == array_Textboxes[i, value].Text)
                                        {
                                            array_Textboxes[i, value - 1].Text = (2 * int.Parse(array_Textboxes[i, value - 1].Text)).ToString();
                                            score += int.Parse(array_Textboxes[i, value - 1].Text);
                                            array_Textboxes[i, value].Text = "";
                                        }
                                        else
                                            break;
                                    }
                                    
                                }
                            }
                        break;
                    }
            }
            return score;
        }
    }
}
