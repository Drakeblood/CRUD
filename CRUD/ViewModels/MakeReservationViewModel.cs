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

        private readonly ObservableCollection<SeanceViewModel> seances;
        public IEnumerable<SeanceViewModel> AvailableSeances => seances;

        private ObservableCollection<SeatViewModel> seats;
        public IEnumerable<SeatViewModel> AvailableSeats => seats;

        public MakeReservationViewModel(CinemaStore _cinemaStore)
        {
            seances = new ObservableCollection<SeanceViewModel>();
            cinemaStore = _cinemaStore;

            seances.Add(new SeanceViewModel(new Seance() { hall_number = 1, id = 1, id_movie = 1, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 2, id = 2, id_movie = 2, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 3, id = 3, id_movie = 1, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 2, id = 4, id_movie = 3, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 2, id = 5, id_movie = 3, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 1, id = 6, id_movie = 2, start_time = DateTime.Now }));

            seats = new ObservableCollection<SeatViewModel>();
            seats.Add(new SeatViewModel(new Seat() { number = 1, available = true }));
            seats.Add(new SeatViewModel(new Seat() { number = 2, available = true }));
            seats.Add(new SeatViewModel(new Seat() { number = 3, available = false }));
            seats.Add(new SeatViewModel(new Seat() { number = 4, available = true }));
            seats.Add(new SeatViewModel(new Seat() { number = 5, available = false }));
            seats.Add(new SeatViewModel(new Seat() { number = 6, available = true }));
            seats.Add(new SeatViewModel(new Seat() { number = 7, available = true }));
            seats.Add(new SeatViewModel(new Seat() { number = 8, available = true }));

            SubmitCommand = new MakeReservationCommand(this, _cinemaStore);
            CancelCommand = new CancelMakeReservationCommand();
        }
    }
}
