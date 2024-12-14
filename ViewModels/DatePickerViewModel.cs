using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_Q4_2024.ViewModels
{
    public class DatePickerViewModel : INotifyPropertyChanged
    {
        private DateTime minDate;
        private DateTime maxDate;
        public DateTime selectedDate;

        public DateTime MinDate
        {
            get
            {
                return minDate;
            }
            set
            {
                minDate = value;
                OnPropertyChanged(nameof(MinDate));
            }
        }

        public DateTime MaxDate
        {
            get
            {
                return maxDate;
            }
            set
            {
                maxDate = value;
                OnPropertyChanged(nameof(MaxDate));
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DatePickerViewModel()
        {
            DateTime fechaActual=DateTime.Now;
            MinDate = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day);
            MaxDate = new DateTime(2024, 12, 31);
            SelectedDate = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day);

        }

    }
}
