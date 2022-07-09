using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUD.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("SeanceDTO")]
        public int SeanceID { get; set; }
        public int SeatNumber { get; set; }
    }

    public class SeanceDTO
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("MovieDTO")]
        public int MovieID { get; set; }
        [ForeignKey("HallDTO")]
        public int HallID { get; set; }
        public DateTime StartTime { get; set; }
    }

    public class HallDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int SeatsCount { get; set; }
    }

    public class MovieDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
