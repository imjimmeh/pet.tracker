using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pets.Tracker.Shared.Models.Contexts;
using Pets.Tracker.Shared.Models.Other.Enums;
using Pets.Tracker.Shared.Models.ViewModels.Admin;

namespace Pets.Tracker.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        private readonly UsersDbContext _context;

        public MainController(UsersDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DatabaseManagement()
        {
            return PartialView("DatabaseManagement", new DatabaseManagementViewModel());
        }

        [HttpGet]
        public IActionResult GetDatabaseView(Database database)
        {
            switch (database)
            {
                case Shared.Models.Other.Enums.Database.Animal:
                    {
                        return PartialView("../Animals");
                    }
                case Shared.Models.Other.Enums.Database.Breed:
                    {
                        return PartialView("../Breed");
                    }
            }

            return NotFound();
        }
    }
}