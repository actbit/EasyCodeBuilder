using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using EasyCodeBuilder.Application.Interfaces;
using EasyCodeBuilder.Core.Interfaces;
using EasyCodeBuilder.Infrastructure.Services;
using EasyCodeBuilder.Presentation.Forms;

namespace EasyCodeBuilder
{
    static class Program
    {
        /// <summary>
        /// サービスプロバイダー（DIコンテナ）
        /// </summary>
        internal static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // DIコンテナの設定
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // MainFormをDIコンテナから取得して起動
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        /// <summary>
        /// DIコンテナにサービスを登録します
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Core Services
            services.AddSingleton<IValidationService, ValidationService>();
            services.AddSingleton<IVariableService, VariableService>();
            services.AddSingleton<ITypeService, TypeService>();

            // Application Services
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<ICompilerService, CompilerService>();
            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddSingleton<IProjectPersistenceService, ProjectPersistenceService>();
            services.AddSingleton<IStatementFactory, StatementFactory>();

            // Forms
            services.AddTransient<MainForm>();
            services.AddTransient<AddControlDialog>();
        }

        /// <summary>
        /// サービスロケーターからサービスを取得します
        /// デザイナー互換性のために使用
        /// </summary>
        public static T GetService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
