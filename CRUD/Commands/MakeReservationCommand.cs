using CRUD.Models;
using CRUD.Stores;
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
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel makeReservationViewModel;
        private readonly CinemaStore cinemaStore;

        public MakeReservationCommand(MakeReservationViewModel _makeReservationViewModel, CinemaStore _cinemaStore)
        {
            makeReservationViewModel = _makeReservationViewModel;
            cinemaStore = _cinemaStore;

            makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return makeReservationViewModel.SeanceID > -1 &&
                makeReservationViewModel.SeatIndex > -1 &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new Reservation();
            reservation.id_seance = makeReservationViewModel.SeanceID;
            reservation.seatNumber = makeReservationViewModel.SeatIndex;
            reservation.reservationTime = DateTime.Now;

            try
            {
                await cinemaStore.MakeReservation(reservation);

                MessageBox.Show("Successfully reserved seat.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.SeanceID) ||
                e.PropertyName == nameof(MakeReservationViewModel.SeatIndex))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
