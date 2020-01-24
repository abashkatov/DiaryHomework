﻿using Homework6.Entity;
using Homework6.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework6.Command
{
    public class DeleteDiaryEntry : ICommand
    {
        public Diary Diary { get; }

        public event EventHandler CanExecuteChanged;
        public DeleteDiaryEntry(Diary diary)
        {
            Diary = diary;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is DiaryEntry)
            {
                Diary.Remove(parameter as DiaryEntry);
            }
        }
    }
}
