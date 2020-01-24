using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.Entity
{
    public class Diary: ICollection, INotifyCollectionChanged, INotifyPropertyChanged
    {
        protected ObservableCollection<DiaryEntry> DiaryEntries { get; set; } = new ObservableCollection<DiaryEntry>();

        public int Count => ((ICollection)DiaryEntries).Count;

        public object SyncRoot => ((ICollection)DiaryEntries).SyncRoot;

        public bool IsSynchronized => ((ICollection)DiaryEntries).IsSynchronized;

        public Diary() {
            SubscribeToDiary();
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        public void Add(DiaryEntry entry)
        {
            DiaryEntries.Add(entry);
        }
        public void Add(IEnumerable<DiaryEntry> NewEntries)
        {
            ResetDiary(DiaryEntries.Concat(NewEntries));
        }
        public void Remove(DiaryEntry entry)
        {
            DiaryEntries.Remove(entry);
        }
        public void CopyTo(Array array, int index)
        {
            ((ICollection)DiaryEntries).CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return ((ICollection)DiaryEntries).GetEnumerator();
        }
        public void OrderByDescending(string Field) 
        {
            ResetDiary(DiaryEntries.OrderByDescending(e => e[Field]));
        }
        public void OrderByAscending(string Field) 
        {
            ResetDiary(DiaryEntries.OrderBy(e => e[Field]));
        }
        public void ResetDiary(IEnumerable<DiaryEntry> NewDiary) 
        {
            DiaryEntries = new ObservableCollection<DiaryEntry>(NewDiary);
            SubscribeToDiary();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        private void SubscribeToDiary() 
        {
            ((INotifyCollectionChanged)DiaryEntries).CollectionChanged += (s, e) => { CollectionChanged?.Invoke(s, e); };
            ((INotifyPropertyChanged)DiaryEntries).PropertyChanged += (s, e) => { PropertyChanged?.Invoke(s, e); };
        }
    }
}
