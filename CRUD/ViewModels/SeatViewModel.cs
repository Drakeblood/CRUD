using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.ViewModels
{
    public class SeatViewModel : ViewModelBase
    {
        private int seatNumber;
        public bool available;

        public string SeatNumber => seatNumber.ToString();
        public char Available => available ? '✓' : 'X';

        public SeatViewModel(int _seatNumber, bool _available)
        {
            seatNumber = _seatNumber;
            available = _available;
        }
    }
}
