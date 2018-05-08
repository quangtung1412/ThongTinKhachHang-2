using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KohansalSoft
{
    public partial class TextboxPrice : UserControl
    {
       
        public string textWithcomma { get; set; }
        public string textWithoutcomma { get; set; }

        public TextboxPrice()
        {
            InitializeComponent();
        }
         
        
        
        //this method converts numbers of textbox to numbers without comma
        
        public string skipComma(string str)
        {

            string[] ss = null;
            string strnew = "";
            if (str == "")
            {
                strnew = "0";
            }
            else
            {
                ss = str.Split(',');
                for (int i = 0; i < ss.Length; i++)
                {
                    strnew += ss[i];
                }
            }
            return strnew;
        }
        //

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "")
            {
                textBox1.Text =null;
                textWithcomma = "0"; //this property maintain the content of textbox with comma
                textWithoutcomma = "0";  //this property maintain the content of textbox without comma
                    
            }
            else
            {

                if (textBox1.Text != "")
                {
                    double d = Convert.ToDouble(skipComma(textBox1.Text));
                    textBox1.Text = d.ToString("#,#", System.Globalization.CultureInfo.InvariantCulture);
                    textWithcomma = textBox1.Text; //this property maintain the content of textbox with comma
                    textWithoutcomma = skipComma(textBox1.Text);  //this property maintain the content of textbox without comma
                }

             
            }
            textBox1.Select(textBox1.Text.Length, 0);
            
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
