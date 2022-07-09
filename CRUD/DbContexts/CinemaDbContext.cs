using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CRUD.DTOs;

namespace CRUD.DbContexts
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ReservationDTO> Reservations { get; set; }

        public DbSet<SeanceDTO> Seances { get; set; }

        public DbSet<HallDTO> Halls { get; set; }

        public DbSet<MovieDTO> Movies { get; set; }
    }
}
