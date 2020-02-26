using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BHR.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult MeetTheTeam()
        {
            return View();
        }

    public IActionResult ContactUs() {
      return View();
    }

  }
}