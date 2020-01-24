using Homework6.Entity;
using Homework6.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework6.Command
{
    public class EditDiaryEntry : ICommand
    {
        public MainWindowContext Context { get; set; }

        public event EventHandler CanExecuteChanged;
        public EditDiaryEntry()
        {
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is DiaryEntry)
            {
                var Window = new DiaryEntryWindow(parameter as DiaryEntry);
                Window.Show();
            }
        }
    }
}
