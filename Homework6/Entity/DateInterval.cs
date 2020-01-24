using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6.Entity
{
    public class DateInterval: INotifyPropertyChanged
    {
        private DateTime dateFrom = DateTime.Now;
        private DateTime dateTo = DateTime.Now.AddDays(-5);
        public DateTime DateFrom { get => dateFrom; 
            set { 
                dateFrom = new DateTime(value.Year, value.Month, value.Day);
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(DateFrom)));
            }
        }

        public DateTime DateTo { get => dateTo;
            set
            {
                dateTo = new DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 999);
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(dateTo)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
