using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Stores
{
    public class CinemaStore
    {
        private readonly Cinema cinema;
        private Lazy<Task> initializeLazy;
        private readonly List<Reservation> reservations;
        public IEnumerable<Reservation> GetReservations => reservations;

        public event Action<Reservation> ReservationMade;

        public Cinema GetCinema => cinema;

        public CinemaStore(Cinema _cinema)
        {
            cinema = _cinema;
            initializeLazy = new Lazy<Task>(Initialize);
            reservations = new List<Reservation>();
        }

        public async Task Load()
        {
            try
            {
                await initializeLazy.Value;
            }
            catch (Exception)
            {
                initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await cinema.MakeReservation(reservation);

            reservations.Add(reservation);

            OnReservationMade(reservation);
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> _reservations = await cinema.GetAllReservations();

            reservations.Clear();
            reservations.AddRange(_reservations);
        }
    }
}
