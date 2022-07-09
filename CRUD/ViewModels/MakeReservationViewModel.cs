using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CRUD.Models;
using CRUD.Commands;
using System.Collections.ObjectModel;
using CRUD.Stores;
using CRUD.DbContexts;

namespace CRUD.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private int seanceID = -1;
        public int SeanceID
        {
            get
            {
                return seanceID;
            }
            set
            {
                seanceID = value;
                UpdateSeats(value);
                OnPropertyChanged(nameof(SeanceID));
            }
        }

        private int seatIndex = -1;
        public int SeatIndex
        {
            get
            {
                return seatIndex;
            }
            set
            {
                seatIndex = value;
                OnPropertyChanged(nameof(SeatIndex));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly CinemaStore cinemaStore;
        private readonly CinemaDbContextFactory cinemaDbContextFactory;

        private readonly ObservableCollection<SeanceViewModel> seances;
        public IEnumerable<SeanceViewModel> AvailableSeances => seances;

        private ObservableCollection<SeatViewModel> seats;
        public IEnumerable<SeatViewModel> AvailableSeats => seats;

        public MakeReservationViewModel(CinemaStore _cinemaStore, CinemaDbContextFactory _cinemaDbContextFactory)
        {
            cinemaStore = _cinemaStore;
            cinemaDbContextFactory = _cinemaDbContextFactory;

            var cinemaDbContext = cinemaDbContextFactory.CreateDbContext();

            seances = new ObservableCollection<SeanceViewModel>();
            {
                var seancesList = cinemaDbContext.Seances.ToList();
                var movieList = cinemaDbContext.Movies.ToList();
                for (int i = 0; i < seancesList.Count; i++)
                {
                    seances.Add(new SeanceViewModel(movieList[seancesList[i].MovieID - 1].Title, seancesList[i].StartTime.ToString(), seancesList[i].HallID.ToString()));
                }
            }

            seats = new ObservableCollection<SeatViewModel>();

            SubmitCommand = new MakeReservationCommand(this, _cinemaStore);
            CancelCommand = new CancelMakeReservationCommand();

            cinemaStore.ReservationMade += OnReservationMade;
        }

        private void OnReservationMade(Reservation reservation)
        {
            System.Diagnostics.Debug.WriteLine(reservation.seatNumber);
        }

        private void UpdateSeats(int seanceID)
        {
            var cinemaDbContext = cinemaDbContextFactory.CreateDbContext();
            seats.Clear();
            for(int i = 0; i < cinemaDbContext.Halls.ToList()[cinemaDbContext.Seances.ToList()[seanceID].HallID - 1].SeatsCount; i++)
            {
                seats.Add(new SeatViewModel(i + 1, true));
            }
        }
    }
}
