using System;
using System.Collections.Generic;
using System.Text;
//import your EntityFrameworkCore to have your class inherit your DbContext abstract class from the entity framework using a directive.
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
//import your Domain models for defining members of your class or fields that will return a DbSet of those Domain models.
using NBAInfo.Domain.Player;
using NBAInfo.Domain.Team;
using NBAInfo.Domain.Coach;

namespace NBAInfo.Data.Database
{
    public class NBAInfoContext : DbContext
    {
        //Have your context constructor inherit itself by the options argument passed in.
        public NBAInfoContext(DbContextOptions<NBAInfoContext> options) : base(options) { }
        //Define fields that will get data from each of your tables.
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }
        //Override your OnModelCreating method so you would your migration would correctly, by decorating your migration with your context.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
