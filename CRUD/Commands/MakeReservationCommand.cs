using CRUD.Models;
using CRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel makeReservationViewModel;
        private readonly Cinema cinema;

        public MakeReservationCommand(MakeReservationViewModel _makeReservationViewModel, Cinema _cinema)
        {
            makeReservationViewModel = _makeReservationViewModel;
            cinema = _cinema;

            makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return makeReservationViewModel.SeanceID > -1 &&
                makeReservationViewModel.SeatNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Reservation reservation = new Reservation();
            reservation.id = cinema.GetReservationsCount() + 1;
            reservation.id_seance = makeReservationViewModel.SeanceID;
            reservation.seatNumber = makeReservationViewModel.SeatNumber;
            reservation.reservationTime = DateTime.Now;

            if (!cinema.MakeReservation(reservation))
            {
                MessageBox.Show("Something went wrong.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            MessageBox.Show("Successfully reserved seat.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.SeanceID) ||
                e.PropertyName == nameof(MakeReservationViewModel.SeatNumber))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
