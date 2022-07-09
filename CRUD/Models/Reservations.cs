using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CRUD.Services.ReservationCreators;
using CRUD.Services.ReservationProviders;
using CRUD.DbContexts;
using CRUD.DTOs;

namespace CRUD.Models
{
    public struct Reservation
    {
        public long id;
        public long id_seance;
        public int seatNumber;
        public DateTime reservationTime;
    }

    public class Reservations
    {
        private readonly CinemaDbContextFactory cinemaDbContextFactory;
        private readonly IReservationCreator reservationCreator;
        private readonly IReservationProvider reservationProvider;

        private readonly List<Reservation> reservations;

        public Reservations(CinemaDbContextFactory _cinemaDbContextFactory, IReservationCreator _reservationCreator, IReservationProvider _reservationProvider)
        {
            reservations = new List<Reservation>();
            cinemaDbContextFactory = _cinemaDbContextFactory;
            reservationCreator = _reservationCreator;
            reservationProvider = _reservationProvider;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await reservationProvider.GetAllReservations();
        }

        public int GetReservationsCount()
        {
            return reservations.Count;
        }

        public async Task AddReservation(Reservation reservation)
        {
            using (CinemaDbContext context = cinemaDbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = await context.Reservations
                    .Where(r => r.SeanceID == reservation.id_seance)
                    .Where(r => r.SeatNumber == reservation.seatNumber)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null)
                {
                    await reservationCreator.CreateReservation(reservation);
                    return;
                }
                throw new Exception();
            }
        }
    }
}
