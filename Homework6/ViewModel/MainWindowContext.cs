using Homework6.Command;
using Homework6.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.ViewModel
{
    public class MainWindowContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Diary Diary { get; }
        private DiaryEntry selectedItem;
        public DiaryEntry SelectedItem { 
            get { 
                return selectedItem; 
            } 
            set {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            } 
        }
        public DateInterval DateInterval { get; set; } = new DateInterval();
        public AddDiaryEntry AddCommand { get; }
        public EditDiaryEntry EditCommand { get; }
        public DeleteDiaryEntry DeleteCommand { get; }
        public LoadDiary LoadDiaryCommand { get; }
        public SaveDiary SaveDiaryCommand { get; }
        public ImportDiary ImportDiaryCommand { get; }
        public SortDiary SortCommand { get; }
        public MainWindowContext(
            Diary diary, 
            AddDiaryEntry addDiaryEntryCommand, 
            EditDiaryEntry editDiaryEntryCommand, 
            DeleteDiaryEntry deleteDiaryEntryCommand,
            LoadDiary loadDiaryCommand,
            SaveDiary saveDiaryCommand,
            ImportDiary importDiaryCommand,
            SortDiary sortDiaryEntryCommand
            ) {
            Diary = diary;

            AddCommand = addDiaryEntryCommand;
            EditCommand = editDiaryEntryCommand;
            DeleteCommand = deleteDiaryEntryCommand;
            LoadDiaryCommand = loadDiaryCommand;
            SaveDiaryCommand = saveDiaryCommand;
            ImportDiaryCommand = importDiaryCommand;
            SortCommand = sortDiaryEntryCommand;
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
