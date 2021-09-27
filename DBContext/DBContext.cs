using first.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.DBContext
{
    public class DBContext: DbContext, IDBContext
    {
        
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
             .HasMany(team => team.Footballers)
             .WithOne(footballer => footballer.Team);
        }

        public DbSet<Footballer> Footballers { get; set; }

        public DbSet<Team> Teams { get; set; }

        public async Task<Footballer> GetFootballerById(int id)
        {
            return await Footballers.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
        public async Task AddFootballer(Footballer footballer)
        {
            await Footballers.AddAsync(footballer);
            SaveChanges();
        }

        public async Task<List<Footballer>> GetFootballers()
        {
            return await Footballers.Include(x=>x.Team).ToListAsync();
        }
        public async Task<List<Team>> GetTeams()
        {
            return await Teams.Include(x=>x.Footballers).ToListAsync();
        }
        public async Task AddTeam(Team team)
        {
            await Teams.AddAsync(team);
            SaveChanges();
        }


    }
}
