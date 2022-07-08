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
        private readonly Seat seat;

        public string SeatNumber => seat.number.ToString();
        public char Available => seat.available ? '✓' : 'X';

        public SeatViewModel(Seat _seat)
        {
            seat = _seat;
        }
    }
}
