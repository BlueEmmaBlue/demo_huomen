using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;


namespace demo_huomen
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            // 创建依赖注入容器
            //var serviceProvider = ConfigureServices();

            //// 创建主窗体并注入服务
            //using (var form = serviceProvider.GetRequiredService<LoginForm>())
            //{
            //    Application.Run(form);
            //}
        }

        private static IServiceProvider ConfigureServices()
        {
            // 创建服务集合
            var services = new ServiceCollection();

            // 注册您的服务和依赖关系
            services.AddSingleton<CookieHandler>();
            services.AddTransient<LoginForm>();
            services.AddTransient<MenuForm>();
            // 返回服务提供程序
            return services.BuildServiceProvider();
        }
    }
}
