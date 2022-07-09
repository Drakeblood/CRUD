using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.DbContexts;
using CRUD.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services.ReservationProviders
{
    class DatabaseReservationProvider : IReservationProvider
    {
        private readonly CinemaDbContextFactory dbContextFactory;

        public DatabaseReservationProvider(CinemaDbContextFactory _dbContextFactory)
        {
            dbContextFactory = _dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (CinemaDbContext context = dbContextFactory.CreateDbContext())
            {
                //await Task.Delay(3000);

                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation() { id_seance = dto.SeanceID, seatNumber = dto.SeatNumber };
        }
    }
}
