using CRUD.Commands;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CRUD.Services;

namespace CRUD.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public ICommand MakeReservationCommand { get; }

        public LoginViewModel(Cinema cinema, NavigationService makeReservationNavigationService)
        {
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        }

        public static LoginViewModel LoadViewModel(Cinema cinema, NavigationService makeReservationNavigationService)
        {
            return new LoginViewModel(cinema, makeReservationNavigationService);
        }
    }
}
