using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using first.Models;
using first.DBContext;
using System.Diagnostics;

namespace first.Controllers
{
    public class HomeController:Controller
    {
        DBContext.DBContext db;
        public HomeController(DBContext.DBContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var teams = await db.GetTeams();
            foreach (var t in teams)
                Debug.Print(t.ToString());
            return View("/Views/Home/Index.cshtml", Tuple.Create<Footballer, List<Team>>(null,  teams));
        }

        public async Task<IActionResult> SecondPage()
        {
            var footballers = await db.GetFootballers();
            return View("/Views/Home/SecondPage.cshtml", footballers);
        }
    }
}
