using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.DTOs;
using CRUD.DbContexts;

namespace CRUD.Services.ReservationCreators
{
    class DatabaseReservationCreator : IReservationCreator
    {
        private readonly CinemaDbContextFactory dbContextFactory;

        public DatabaseReservationCreator(CinemaDbContextFactory _dbContextFactory)
        {
            dbContextFactory = _dbContextFactory;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            using (CinemaDbContext context = dbContextFactory.CreateDbContext())
            {
                await Task.Delay(3000);

                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                SeanceID = reservation.id_seance,
                SeatNumber = reservation.seatNumber
            };
        }
    }
}
