using Homework6.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.ViewModel
{
    public class DiaryEntryWindowContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DiaryEntry DiaryEntry { get; set; }
        public DiaryEntryWindowContext(DiaryEntry diaryEntry) 
        {
            DiaryEntry = diaryEntry;
        }
    }
}
