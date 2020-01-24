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
using System.Windows.Shapes;

namespace Homework6
{
    /// <summary>
    /// Логика взаимодействия для DiaryEntriWindow.xaml
    /// </summary>
    public partial class DiaryEntryWindow : Window
    {
        internal DiaryEntry DiaryEntry { get; set; }
        public DiaryEntryWindow(DiaryEntry diaryEntry)
        {
            InitializeComponent();
            var context = new DiaryEntryWindowContext(diaryEntry);
            DataContext = context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
