using System;
using System.Windows.Forms;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

namespace demo_huomen
{
    public partial class DataForm : Form
    {
        public string usrname;
        
        public DataForm(string username)
        {
            InitializeComponent();
            usrname = username;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // 关闭 SecondForm
            // 登录成功，跳转到主窗体
                var menuForm = new MenuForm(usrname);
            //MenuForm menuForm = new MenuForm(username, );
            menuForm.Show();
            this.Close(); // 隐藏登录窗体，或者可以使用 this.Close() 来关闭登录窗体
        }
    }
}
