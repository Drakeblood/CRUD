using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Services.ReservationProviders
{
    public interface IReservationProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}
