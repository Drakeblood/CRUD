using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CRUD.ViewModels;
using CRUD.Models;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Cinema cinema;

        public App()
        {
            cinema = new Cinema();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(cinema)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
