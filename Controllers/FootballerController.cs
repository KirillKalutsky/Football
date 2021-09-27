using first.DBContext;
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
    public class FootballerController : Controller
    {
        private DBContext.DBContext db;
        public FootballerController(DBContext.DBContext db)
        {
            this.db = db;
        }
       

        [HttpPost("/createFootballer")]
        public async Task<IActionResult> CreateFootballer([FromForm]Footballer footballer)
        {
            var team = footballer.Team;
            Debug.Print($"{team.Name} { team.Id}");
            await db.AddFootballer(footballer);
            var teams = await db.GetTeams();
            return View("/Views/Home/Index.cshtml",Tuple.Create<Footballer,List<Team>>(null,teams));
        }
      
    }
}
