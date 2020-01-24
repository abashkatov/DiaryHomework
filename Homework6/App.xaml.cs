using Homework6.Builder;
using Homework6.Command;
using Homework6.Entity;
using Homework6.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Homework6
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        void AppStartup(Object sender, StartupEventArgs e)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<MainWindow, MainWindow>();
            services.AddTransient<MainWindowContext, MainWindowContext>();
            services.AddTransient<AddDiaryEntry, AddDiaryEntry>();
            services.AddTransient<EditDiaryEntry, EditDiaryEntry>();
            services.AddTransient<DeleteDiaryEntry, DeleteDiaryEntry>();
            services.AddTransient<SortDiary, SortDiary>();
            services.AddTransient<SaveDiary, SaveDiary>();
            services.AddTransient<LoadDiary, LoadDiary>();
            services.AddTransient<ImportDiary, ImportDiary>();

            // For test
            services.AddTransient<Sentence, Sentence>();
            services.AddTransient<FakeDiaryEntry, FakeDiaryEntry>();

            var Diary = new Diary();
            services.AddSingleton<Diary>(Diary);
            
            var provider = services.BuildServiceProvider();
            MainWindow mainWindow = provider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
