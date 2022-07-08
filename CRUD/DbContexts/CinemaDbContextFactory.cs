using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRUD.DbContexts
{
    public class CinemaDbContextFactory
    {
        private readonly string connectionString;

        public CinemaDbContextFactory(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public CinemaDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            return new CinemaDbContext(options);
        }
    }
}
