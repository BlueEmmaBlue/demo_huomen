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

    public partial class LoginForm : Form
    {
        //private readonly CookieHandler _cookieHandler;
        //private readonly IServiceProvider serviceProvider;

        public LoginForm()
        {
            InitializeComponent();
            //_cookieHandler = cookieHandler;
            // 存储 serviceProvider
            //_serviceProvider = serviceProvider;
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

        private async Task login(string username, string password)
        {
            string apiUrl = "http://localhost:8080/device-test/api/auth/login";
            // 创建一个 HttpClientHandler 实例，用于配置请求处理方式
            HttpClientHandler handler = new HttpClientHandler();

            //// 在登录窗口中保存 Cookie
            //var cookieContainer = SharedCookieContainer.Instance.CookieContainer;
            //var cookie = new Cookie(username, Guid.NewGuid().ToString());
            //cookieContainer.Add(new Uri("http://localhost:8080/device-test"), cookie);
            //// 添加随机生成的Cookie到请求中
            //handler.CookieContainer = new CookieContainer();
            //handler.CookieContainer.Add(new Uri(apiUrl), new Cookie("random_cookie", randomCookieValue));

            // 创建一个 HttpClient 实例，并传入自定义的 HttpClientHandler
            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    // 构造要发送的登录数据，通常是用户名和密码
                    var loginData = new
                    {
                        Username = username,
                        Password = password
                    };

                    // 将登录数据序列化为 JSON 字符串
                    string jsonLoginData = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);

                    // 设置请求头，指定请求内容类型为 JSON
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // 发送 HTTP POST 请求
                    HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonLoginData, System.Text.Encoding.UTF8, "application/json"));

                    // 检查响应是否成功
                    if (response.IsSuccessStatusCode)
                    {
                        // 读取响应内容
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("登录成功，响应内容：" + responseContent);
                        // 获取登录后的Cookie
                        IEnumerable<string> cookies = response.Headers.GetValues("Set-Cookie");

                        // 将Cookie添加到共享的CookieContainer中
                        var cookieContainer = SharedCookieContainer.Instance.CookieContainer;
                        foreach (var cookieHeaderValue in cookies)
                        {
                            cookieContainer.SetCookies(new Uri("http://localhost:8080/device-test/api"), cookieHeaderValue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("登录失败，状态码：" + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("发生异常：" + ex.Message);
                }
            }
        }


        private async void btnLogin_Click(object sender, EventArgs e)
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

            if (IsValidLogin(username, password))
            {
                // 登录成功，跳转到主窗体
                var menuForm = new MenuForm(username);
                //MenuForm menuForm = new MenuForm(username, );
                menuForm.Show();
                this.Hide(); // 隐藏登录窗体，或者可以使用 this.Close() 来关闭登录窗体
            }else
            {
                MessageBox.Show("登录错误");
            }
            

            //HttpClientHandler handler = new HttpClientHandler();

            //using (HttpClient client = new HttpClient(handler))
            //{
            //    try
            //    {
            //        var loginData = new
            //        {
            //            username = username,
            //            password = password
            //        };
            //        string jsonLoginData = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);
            //        string apiUrl = "http://localhost:8080/device-test/api/auth/login";
            //        HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonLoginData, System.Text.Encoding.UTF8, "application/json"));
            //        // 检查响应是否成功
            //        if (response.IsSuccessStatusCode)
            //        {
            //            // 读取响应内容
            //            string responseContent = await response.Content.ReadAsStringAsync();
            //            Console.WriteLine("登录成功，响应内容：" + responseContent);

            //            // 将Cookie添加到共享的CookieContainer中
            //            IEnumerable<string> cookies = response.Headers.GetValues("Set-Cookie");
            //            var cookieContainer = SharedCookieContainer.Instance.CookieContainer;
            //            foreach (var cookieHeaderValue in cookies)
            //            {
            //                cookieContainer.SetCookies(new Uri("http://localhost:8080/device-test/api"), cookieHeaderValue);
            //            }
            //            // 登录成功，跳转到主窗体
            //            var menuForm = new MenuForm(username);
            //            //MenuForm menuForm = new MenuForm(username, );
            //            menuForm.Show();
            //            this.Hide(); // 隐藏登录窗体，或者可以使用 this.Close() 来关闭登录窗体
            //        }
            //        else
            //        {
            //            //Console.WriteLine("登录失败，状态码：" + response.StatusCode);
            //            // 登录失败，弹出密码错误的消息框
            //            MessageBox.Show("用户名或密码错误，请重试。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //Console.WriteLine("发生异常：" + ex.Message);
            //        MessageBox.Show("发生异常：", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
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
