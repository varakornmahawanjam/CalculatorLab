using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            numberBtn_Click("0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            check = 0;
            first_num = 0;
            second_num = 0;
            hold = "";
            look1 = 0;
            look2 = 0;
            sum = 0;
            remember = 0;
            swicth = true;
        }
        void numberBtn_Click(string s)
        {
            if (check == 1 && first_num == 0)
            {
                first_num = float.Parse(lblDisplay.Text);
                check = 0;
                lblDisplay.Text = "0";
            }
            if (s == "." && lblDisplay.Text == "0")
            {
                lblDisplay.Text = "0.";
            }
            else if (lblDisplay.Text == "0" || lblDisplay.Text == "+" || lblDisplay.Text == "-" || lblDisplay.Text == "X" || lblDisplay.Text == "÷")
            {
                lblDisplay.Text = s;
            }
            else 
            {
                lblDisplay.Text = lblDisplay.Text + s;
            }
            if (first_num != 0 && !hold.Contains(".") && check == 2)
            {
                hold += ".";
            }
            if (check == 1 && hold != "")
            {
                second_num = float.Parse(hold);
                if (remember == 1)
                {
                    second_num = first_num * second_num / 100;
                }
                hold = "";
                btnOperator_Click();
                check = 0;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int length =lblDisplay.Text.Length;
            lblDisplay.Text = lblDisplay.Text.Remove(length - 1, 1);
            check = 0;
            look1 = 0;
        }
        int look1 =0;
        int look2 = 0;
        int check = 0;
        string hold = "";
        float sum = 0;
        float first_num = 0;
        float second_num = 0;
        int remember = 0;
        bool swicth = true;
        
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (swicth)
            {
                check = 2;
                numberBtn_Click(".");
                swicth = false;
            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            look1 = 4;
            check = 1;
            swicth = true;
            numberBtn_Click("");
            look2 = look1;
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            look1 = 1;
            check = 1;
            swicth = true;
            numberBtn_Click("");
            look2 = look1;
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            remember = 1;
            lblDisplay.Text = lblDisplay.Text + "%";
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            look1 = 3;
            check = 1;
            swicth = true;
            numberBtn_Click("");
            look2 = look1;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            look1 = 2;
            check = 1;
            swicth = true;
            numberBtn_Click("");
            look2 = look1;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            second_num = float.Parse(lblDisplay.Text);
            if (remember == 1)
            {
                second_num = first_num * second_num / 100;
            }
            hold = "";
            if (look1 == 1)
            {
                sum = first_num / second_num;
            }
            else if (look1 == 2)
            {
                sum = first_num * second_num;
            }
            else if (look1 == 3)
            {
                sum = first_num - second_num;
            }
            else if (look1 == 4)
            {
                sum = first_num + second_num;
            }
            lblDisplay.Text = sum.ToString();
            first_num = sum;
            sum = 0;
            remember = 0;
        }
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = ((Button)sender).Text;
            }
            else if (lblDisplay.Text.Length < 8)
            {
                lblDisplay.Text = lblDisplay.Text + ((Button)sender).Text;
                if (first_num != 0 && ((Button)sender).Text != "+" && ((Button)sender).Text != "-" && ((Button)sender).Text != "X" && ((Button)sender).Text != "÷" && ((Button)sender).Text != "%")
                {
                    hold += ((Button)sender).Text;
                }
            }
        }
        void btnOperator_Click()
        {
            if (look2 == 1)
            {
                sum = first_num / second_num;
            }
            else if (look2 == 2)
            {
                sum = first_num * second_num;
            }
            else if (look2 == 3)
            {
                sum = first_num - second_num;
            }
            else if (look2 == 4)
            {
                sum = first_num + second_num;
            }
            lblDisplay.Text = "0";
            first_num = sum;
            remember = 0;
        }
    }
}