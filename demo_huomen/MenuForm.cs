using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_huomen
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 根据选择的选项卡索引切换内容面板上的控件的可见性
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    tabPage1.Show();
                    //panel1.Controls.Clear();
                    //panel1.Controls.Add(label1); // 这里的label1是你希望显示的控件
                    break;
                case 1:
                    tabPage2.Show();
                    //panel1.Controls.Clear();
                    //panel1.Controls.Add(textBox1); // 这里的textBox1是你希望显示的控件
                    break;
                // 添加更多的选项卡和相应的控件
                default:
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
