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
            return true;
            //return !string.IsNullOrEmpty(makeReservationViewModel.Username) &&
            //    makeReservationViewModel.FloorNumber > 0 &&
            //    base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("Test");
            Reservation reservation = new Reservation();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if(e.PropertyName == nameof(MakeReservationViewModel.Username) ||
            //    e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
