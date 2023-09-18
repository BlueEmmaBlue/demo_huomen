using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // 引入MySQL连接器的命名空间
using System.Data;

namespace demo_huomen
{
    public partial class LoginForm : Form
    {
        MySqlConnection connection;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // 读取上次密码
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Username))
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
                chkRememberPassword.Checked = true;
            }

            // 连接数据库
            string connectionString = "Server=shiweiyan-surface;Database=huomen;Uid=root;Pwd=123;";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("连接成功！");
                // 连接成功后可以执行数据库操作
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void rmbBtn_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (chkRememberPassword.Checked)
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Save();
            }

            // 进行登录验证逻辑
            // 如果验证成功，进行相应操作
            // 否则，显示错误消息
            if (IsValidLogin(username, password))
            {
                // 登录成功，跳转到主窗体
                MenuForm menuForm = new MenuForm(username);
                menuForm.Show();
                this.Hide(); // 隐藏登录窗体，或者可以使用 this.Close() 来关闭登录窗体
            }
            else
            {
                // 登录失败，弹出密码错误的消息框
                MessageBox.Show("用户名或密码错误，请重试。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            // 这里执行实际的登录验证逻辑，检查用户名和密码是否正确
            // 如果正确返回 true，否则返回 false
            // 你的验证逻辑可能涉及数据库查询或其他方式的验证
            // 这里只是一个示例，你需要根据你的实际需求进行修改
            if (username == "admin" && password == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
