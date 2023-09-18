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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            cbbxRegisterRole.Items.Add("管理员");
            cbbxRegisterRole.Items.Add("普通用户");

            // 添加事件处理程序，以便在选择项时触发事件
            //cbbxRegisterRole.SelectedIndexChanged += cbbxRegisterRole_SelectedIndexChanged;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool IsUsernameAvailable(string username)
        {
            // 执行查询操作，检查用户名是否已存在
            // 这里只是一个示例，具体实现会根据你的存储方式而有所不同
            // 可以使用数据库查询或集合的方式来实现
            // 假设users是一个存储用户信息的集合
            //return !users.Any(user => user.Username == username);
            return true;
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 执行用户注册逻辑，将新用户添加到用户存储中

            string username = txtRegisterUsername.Text;

            // 检查用户名是否可用
            if (!IsUsernameAvailable(username))
            {
                MessageBox.Show("用户名已存在，请选择另一个用户名。");
                return; // 阻止注册
            }
            // 执行用户注册逻辑，将新用户添加到用户存储中
            else
            {
                MessageBox.Show("注册成功！");
                DialogResult = DialogResult.OK; // 设置对话框的结果为OK
                Close(); // 关闭注册窗口
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbxRegisterRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cbbxRegisterRole.SelectedItem.ToString();
            MessageBox.Show("选择了：" + selectedOption);
        }
    }
}
