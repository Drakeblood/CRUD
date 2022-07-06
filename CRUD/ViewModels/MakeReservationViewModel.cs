using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CRUD.Models;
using CRUD.Commands;

namespace CRUD.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private int seanceID = 6;
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

        private DateTime reservationTime;
        public DateTime ReservationTime
        {
            get
            {
                return reservationTime;
            }
            set
            {
                reservationTime = value;
                OnPropertyChanged(nameof(ReservationTime));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly Seances seances;

        public MakeReservationViewModel(Seances _seances)
        {
            seances = _seances;
            SubmitCommand = new MakeReservationCommand(this, null);
            CancelCommand = new CancelMakeReservationCommand();
        }
    }
}
