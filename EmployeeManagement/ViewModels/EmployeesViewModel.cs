using EmployeeManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.ViewModels
{
    class EmployeesViewModel : INotifyPropertyChanged, IEmployeesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private IEmployeeRepository _employeeRepository;
        public EmployeesViewModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            FillListView();
            FillFilterMessage();
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private string _filter;
        public string Filter
        {
            get 
            { 
                return _filter; 
            }
            set
            {
                _filter = value;
                FillListView();
                FillFilterMessage();
            }
        }

        private string _filterMessage;
        public string FilterMessage
        {
            get
            {
                return _filterMessage;
            }
            set
            {
                _filterMessage = value;
                OnPropertyChanged();
            }
        }
        private void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                Employees = new ObservableCollection<Employee>(
                    _employeeRepository.GetAll()
                    .Where(v => v.FirstName.Contains(_filter)));
            }
            else
                Employees = new ObservableCollection<Employee>(
                    _employeeRepository.GetAll());
        }

        private void FillFilterMessage()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                FilterMessage = "По вашему запросу найдено: " + Employees.Count().ToString();
            }
            else
            {
                FilterMessage = "Введите данные для поиска";
            }
        }
    }
}
