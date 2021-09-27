using first.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace first.Controllers
{
    [Route("")]
    [ApiController]
    public class TeamController : Controller
    {
        private DBContext.DBContext db;
        public TeamController(DBContext.DBContext db)
        {
            this.db = db;
        }
        // GET: TeamController
        [HttpPost("/createTeam")]
        public async Task<ActionResult> CreateTeam([FromForm]string name)
        {
            Debug.Print("Новая команда "+name);
            await db.AddTeam(new Team() { Name = name });
            var teams = await db.GetTeams();
            return View("/Views/Home/Index.cshtml", Tuple.Create<Footballer, List<Team>>(null, teams));
        }

        
       
    }
}
