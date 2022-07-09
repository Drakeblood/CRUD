﻿using System;
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
using CRUD.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
        private readonly CinemaStore cinemaStore;
        private readonly NavigationStore navigationStore;

        public App()
        {
            cinemaDbContextFactory = new CinemaDbContextFactory(CONNECTION_STRING);
            cinema = new Cinema(new Reservations(cinemaDbContextFactory, new DatabaseReservationCreator(cinemaDbContextFactory), new DatabaseReservationProvider(cinemaDbContextFactory)));
            cinemaStore = new CinemaStore(cinema);
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (CinemaDbContext cinemaDbContex = cinemaDbContextFactory.CreateDbContext())
            {
                // check if was added
                if (cinemaDbContex.Halls.Count() <= 0)
                {
                    cinemaDbContex.Movies.Add(new MovieDTO() { Title = "Thor" });
                    cinemaDbContex.Movies.Add(new MovieDTO() { Title = "Ennio" });
                    cinemaDbContex.Movies.Add(new MovieDTO() { Title = "Yang" });

                    cinemaDbContex.Halls.Add(new HallDTO() { SeatsCount = 30 });
                    cinemaDbContex.Halls.Add(new HallDTO() { SeatsCount = 20 });
                    cinemaDbContex.Halls.Add(new HallDTO() { SeatsCount = 40 });

                    cinemaDbContex.Seances.Add(new SeanceDTO() { HallID = 1, MovieID = 1, StartTime = new DateTime(2022, 7, 9, 10, 0, 0) });
                    cinemaDbContex.Seances.Add(new SeanceDTO() { HallID = 2, MovieID = 2, StartTime = new DateTime(2022, 7, 9, 10, 0, 0) });
                    cinemaDbContex.Seances.Add(new SeanceDTO() { HallID = 3, MovieID = 3, StartTime = new DateTime(2022, 7, 9, 10, 0, 0) });
                    cinemaDbContex.Seances.Add(new SeanceDTO() { HallID = 1, MovieID = 3, StartTime = new DateTime(2022, 7, 9, 14, 0, 0) });
                    cinemaDbContex.Seances.Add(new SeanceDTO() { HallID = 3, MovieID = 2, StartTime = new DateTime(2022, 7, 9, 13, 0, 0) });

                    cinemaDbContex.SaveChanges();
                }  
                cinemaDbContex.Database.Migrate();
            }

            navigationStore.CurrentViewModel = new MakeReservationViewModel(cinemaStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
