using Exercices07.Models;
using Exercices07.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exercices07.Controllers
{
    public class HomeController : Controller
    {
        private readonly SportContext context;

        public HomeController(SportContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            return View(context.Sports.ToList());
        }

        public IActionResult TeamsBySport(int id)
        {
            ViewBag.sport = context.Sports.Find(id);
            return View(context.Sports.Find(id)?.Teams?.ToList());
        }

        public IActionResult CreateTeam(int id)
        {
            ViewBag.sport = context.Sports.Find(id);
            return View();
        }

        public IActionResult CreateTeamSubmit(string Name, DateTime FoundingDate, int SportId)
        {
            var team = new Team()
            {
                Name = Name,
                FoundingDate = FoundingDate,
                SportId = SportId
            };
            context.Teams.Add(team);
            context.SaveChanges();
            return RedirectToAction("TeamsBySport", new {id = SportId});
        }

        public IActionResult PlayersByTeam(int id) //id de team
        {
            ViewBag.team = context.Teams.Find(id);
            return View(context.Teams.Find(id)?.Players?.ToList());
        }

        public IActionResult CreatePlayer(int id)
        {
            ViewBag.team = context.Teams.Find(id);
            return View();
        }

        public IActionResult CreatePlayerSubmit(string FirstName, string LastName, DateTime DateOfBirth, int TeamId)
        {
            var player = new Player()
            {
               LastName = LastName,
               FirstName = FirstName,
               DateOfBirth = DateOfBirth, 
               TeamId = TeamId
            };
            context.Players.Add(player);
            context.SaveChanges();
            return RedirectToAction("PlayersByTeam", new { id = TeamId });
        }

        public IActionResult TransferPlayer(int id)  //id de player
        {
           
            var player = context.Players.Find(id);
            ViewBag.teams = context.Sports.Find(player?.Team?.SportId)?.Teams?.ToList();
            return View(player);
        }

        public IActionResult TransferPlayerSubmit(int id, int TeamDestinationId)
        {

            var player = context.Players.Find(id);
            player.TeamId = TeamDestinationId;
            context.Update(player);
            context.SaveChanges();
            return RedirectToAction("PlayersByTeam", new { id = TeamDestinationId });
        }

        public IActionResult TrophiesWonByTeam(int id) //id de team
        {
            ViewBag.team = context.Teams.Find(id);
            return View(context.Teams.Find(id)?.Trophies?.ToList());
        }

        public IActionResult CreateTrophy(int id)
        {
            ViewBag.team = context.Teams.Find(id);
            return View();
        }

        public IActionResult CreateTrophySubmit(string Name, int Year, int TeamId)
        {
            var trophy = new Trophy()
            {
                Name = Name,
                Year = Year,
                TeamId = TeamId
            };
            context.Trophies.Add(trophy);
            context.SaveChanges();
            return RedirectToAction("TrophiesWonByTeam", new { id = TeamId });
        }

        public IActionResult ListTrophies()
        {
            
            var names = context.Trophies.Select(t => t.Name).Distinct().ToList();
            //ViewBag.team = context.Teams.Find(id);
            return View(names);
        }

        public IActionResult WinningTeamsOfTrophy(string name)
        {
            var trophies = context.Trophies?.Where(t => t.Name == name).ToList();
            var teams = new Dictionary<int, string>();
            foreach (var item in trophies)
            {
                teams.Add(item.Year, item.Team.Name);
            }

            ViewBag.Teams = teams;
            return View("ListTrophies", context.Trophies.Select(t => t.Name).Distinct().ToList());
        }
    }
}
