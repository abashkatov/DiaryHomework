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
    public class AddDiaryEntry : ICommand
    {
        protected Diary Diary { get; }

        public event EventHandler CanExecuteChanged;
        public AddDiaryEntry(Diary diary)
        {
            Diary = diary;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var entry = new DiaryEntry();
            var Window = new DiaryEntryWindow(entry);
            Window.Closed += (object sender, EventArgs e) => {
                entry.Num = Diary.Count + 1;
                Diary.Add(entry); 
            };
            Window.Show();
        }
    }
}
