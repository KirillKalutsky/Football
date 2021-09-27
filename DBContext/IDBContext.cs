using first.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first.DBContext
{
    public interface IDBContext
    {
        public Task<Footballer> GetFootballerById(int id);
        public Task AddFootballer(Footballer footballer);
        public Task<List<Footballer>> GetFootballers();
        public Task<List<Team>> GetTeams();
        public Task AddTeam(Team team);
        
    }
}
