﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities;

namespace TransportIS.DAL
{
    public class TransportISDbContext : DbContext
    {
        public TransportISDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CarrierEntity>? Carriers { get; set; }

        public DbSet<ConnectionEntity>? Connections { get; set; }

        public DbSet<EmploeeEntity>? Emploees { get; set; }

        public DbSet<PassengerEntity>? Passengers { get; set; }

        public DbSet<StopEntity>? Stops { get; set; }

        public DbSet<TicketEntity>? Tickets { get; set; }

        public DbSet<TimeTableEntity>? TimeTables { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionEntity>()
                .HasOne<CarrierEntity>()
                .WithMany(ConnectionEntity => ConnectionEntity.)
        }
        */
    }
}
