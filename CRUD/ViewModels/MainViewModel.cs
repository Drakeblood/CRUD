using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;
using CRUD.Stores;

namespace CRUD.ViewModels
{
    public class MainViewModel : ViewModelBase 
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore _navigationStore)
        {
            navigationStore = _navigationStore;
        }
    }
}
