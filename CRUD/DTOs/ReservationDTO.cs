using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public long SeanceID { get; set; }
        public int SeatNumber { get; set; }
    }
}
