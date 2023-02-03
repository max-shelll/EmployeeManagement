using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace EmployeeManagement
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();

            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IEmployeeViewModel, EmployeeViewModel>();
            container.RegisterType<IEmployeesViewModel, EmployeesViewModel>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            container.Resolve<EmployeesView>().Show();
        }
    }
}
