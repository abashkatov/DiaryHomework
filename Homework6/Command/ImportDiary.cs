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
    public class ImportDiary : ICommand
    {
        public Diary Diary { get; }

        public event EventHandler CanExecuteChanged;
        public ImportDiary(Diary diary)
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
                    DiaryEntry[] DiaryEntries = formatter.Deserialize(fs) as DiaryEntry[];
                    if (parameter is DateInterval)
                    {
                        var Interval = parameter as DateInterval;
                        Interval.DateTo = Interval.DateTo;
                        Diary.Add(DiaryEntries.Where(e => { return e.Createdon >= Interval.DateFrom && e.Createdon <= Interval.DateTo; }));
                        return;
                    }
                    Diary.Add(DiaryEntries);
                }
            }
        }
    }
}
