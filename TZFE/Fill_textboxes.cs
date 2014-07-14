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
     public class Fill_textboxes
    {

         public void Fill_random(TextBox[,] array_Textboxes)
         {

             //rnd - рандом
             //x,y- ячейки заполнения
             //stat - пустая ячейка или нет
             Random rnd = new Random();
             int x, y;
             x = rnd.Next(0, 4);
             y = rnd.Next(0, 4);
             bool stat = false;
             bool Space = false;

             foreach (TextBox tb in array_Textboxes)
             {
                 if (tb.Text == "")
                 {
                     Space = true;
                     break;
                 }
             }

             if (Space)
             {
                 while (stat == false)
                 {
                     //Проверка свободной клетки заполнения
                     if (array_Textboxes[x, y].Text == "")
                     {
                         //Случайное выпадения 2(90%) или 4(10%)
                         if (rnd.Next(0, 101) <= 90)
                             array_Textboxes[x, y].Text = "2";
                         else
                             array_Textboxes[x, y].Text = "4";
                         stat = true;
                     }
                     else
                     {
                         x = rnd.Next(0, 4);
                         y = rnd.Next(0, 4);
                     }
                 }
                 Space = false;
             }
         }       
    }
}
