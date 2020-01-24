using Homework6.Entity;
using Homework6.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework6.Command
{
    public class SortDiary : ICommand
    {
        public Diary Diary { get; }

        public event EventHandler CanExecuteChanged;
        private string OrderField = null;
        private string OrderDirection = "ASC";
        public SortDiary(Diary diary)
        {
            Diary = diary;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if ((string)parameter != OrderField)
            {
                OrderField = (string)parameter;
                OrderDirection = "ASC";
            }
            else {
                OrderDirection = (OrderDirection == "ASC") ? "DESC" : "ASC";
            }
            if (OrderDirection == "ASC")
            {
                Diary.OrderByAscending(OrderField);
            }
            else {
                Diary.OrderByDescending(OrderField);
            }
        }
    }
}
