using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using CRUD.ViewModels;
using CRUD.Models;
using CRUD.Stores;
using CRUD.DbContexts;
using CRUD.Services.ReservationCreators;
using CRUD.Services.ReservationProviders;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=cinema.db";

        private readonly CinemaDbContextFactory cinemaDbContextFactory;
        private readonly Cinema cinema;
        private readonly NavigationStore navigationStore;

        public App()
        {
            cinemaDbContextFactory = new CinemaDbContextFactory(CONNECTION_STRING);
            cinema = new Cinema(new Reservations(new DatabaseReservationCreator(cinemaDbContextFactory), new DatabaseReservationProvider(cinemaDbContextFactory)));
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (CinemaDbContext cinemaDbContex = cinemaDbContextFactory.CreateDbContext())
            {
                cinemaDbContex.Database.Migrate();
            }

            navigationStore.CurrentViewModel = new MakeReservationViewModel(cinema);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
