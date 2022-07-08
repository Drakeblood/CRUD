using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Services.ReservationCreators
{
    public interface IReservationCreator
    {
        Task CreateReservation(Reservation reservation);
    }
}
