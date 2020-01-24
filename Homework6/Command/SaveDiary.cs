using Homework6.Entity;
using Homework6.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework6.Command
{
    public class SaveDiary : ICommand
    {
        protected Diary Diary { get; }

        public event EventHandler CanExecuteChanged;
        public SaveDiary(Diary diary)
        {
            Diary = diary;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "diary files (*.diary)|*.diary";
            saveFileDialog.DefaultExt = "diary";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate)) 
                {
                    SoapFormatter formatter = new SoapFormatter();
                    DiaryEntry[] rows = new DiaryEntry[Diary.Count];
                    Diary.CopyTo(rows, 0);
                    formatter.Serialize(fs, rows);
                }
            }
        }
    }
}
