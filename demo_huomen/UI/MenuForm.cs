using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace demo_huomen
{
    public partial class MenuForm : Form
    {
        //private readonly CookieHandler _cookieHandler;

        public MenuForm(string username)
        {
            InitializeComponent();
            //_cookieHandler = cookieHandler;
            // 使用DateTime.Now获取当前时间
            DateTime currentTime = DateTime.Now;

            // 将时间格式化为字符串，例如 "yyyy-MM-dd HH:mm:ss"
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            lblUsername.Text = "当前用户：" + username + " " + formattedTime;
        }

        private async Task getUserList()
        {
            string apiUrl = "http://localhost:8080/device-test/szUser/list";
            dgvUserList.AutoGenerateColumns = true;
            var cookieContainer = SharedCookieContainer.Instance.CookieContainer;
            HttpClient client = new HttpClient(new HttpClientHandler
            {
                CookieContainer = cookieContainer
            });
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                // 解析JSON字符串为.NET对象，例如List<T>
                Response<User[]> apiResponse = JsonConvert.DeserializeObject<Response<User[]>>(jsonContent);
                //System.Diagnostics.Debug.WriteLine(json);
                dgvUserList.DataSource = apiResponse.data;
            }
        }


        private async void MenuForm_Load(object sender, EventArgs e)
        {
            await getUserList();
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

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 创建注册窗口的实例
            RegisterForm registrationForm = new RegisterForm();

            // 显示注册窗口作为对话框
            DialogResult result = registrationForm.ShowDialog();

            // 检查对话框返回的结果
            if (result == DialogResult.OK)
            {
                // 注册成功，你可以在这里执行相应的操作
            }
            else
            {
                // 注册窗口被取消或关闭
                registrationForm.Close();
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }
    }
}
