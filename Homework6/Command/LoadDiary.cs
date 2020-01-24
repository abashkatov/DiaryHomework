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
    public class LoadDiary : ICommand
    {
        protected Diary Diary { get; }

        public event EventHandler CanExecuteChanged;
        public LoadDiary(Diary diary)
        {
            Diary = diary;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "diary files (*.diary)|*.diary";
            openFileDialog.DefaultExt = "diary";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate))
                {
                    SoapFormatter formatter = new SoapFormatter();
                    Diary.ResetDiary(formatter.Deserialize(fs) as DiaryEntry[]);
                }
            }
        }
    }
}
