using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CRUD.Models;
using CRUD.Commands;
using System.Collections.ObjectModel;

namespace CRUD.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private int seanceID;
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

        private int seatNumber;
        public int SeatNumber
        {
            get
            {
                return seatNumber;
            }
            set
            {
                seatNumber = value;
                OnPropertyChanged(nameof(SeatNumber));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Cinema cinema;

        private readonly ObservableCollection<SeanceViewModel> seances;
        public IEnumerable<SeanceViewModel> AvailableSeances => seances;

        public MakeReservationViewModel(Cinema _cinema)
        {
            seances = new ObservableCollection<SeanceViewModel>();
            cinema = _cinema;
            
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 1, id = 1, id_movie = 1, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 2, id = 2, id_movie = 2, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 3, id = 3, id_movie = 1, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 2, id = 4, id_movie = 3, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 2, id = 5, id_movie = 3, start_time = DateTime.Now }));
            seances.Add(new SeanceViewModel(new Seance() { hall_number = 1, id = 6, id_movie = 2, start_time = DateTime.Now }));

            SubmitCommand = new MakeReservationCommand(this, _cinema);
            CancelCommand = new CancelMakeReservationCommand();
        }
    }
}
