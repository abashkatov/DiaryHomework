using Homework6.Builder;
using Homework6.Entity;
using Homework6.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowContext context, Diary diary, FakeDiaryEntry fakeDiaryEntryBuilder)
        {
            InitializeComponent();

            DataContext = context;
            Diary = diary;
            FakeDiaryEntryBuilder = fakeDiaryEntryBuilder;
            Diary.Add(FakeDiaryEntryBuilder.Builder());
            Diary.Add(FakeDiaryEntryBuilder.Builder());
            Diary.Add(FakeDiaryEntryBuilder.Builder());
            Diary.Add(FakeDiaryEntryBuilder.Builder());
            Diary.Add(FakeDiaryEntryBuilder.Builder());
            Diary.Add(FakeDiaryEntryBuilder.Builder());
        }

        public Diary Diary { get; }
        public FakeDiaryEntry FakeDiaryEntryBuilder { get; }
    }
}
