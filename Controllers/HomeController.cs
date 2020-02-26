using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BHR.Models;
using BHR.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BHR.Controllers {
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
      _logger = logger;
    }

    public IActionResult Index() {
      using (var db = new DBHRDBContext()){
        PageVM model = new PageVM(db.Page.Include(x => x.ContentBlock).FirstOrDefault(x => x.Name == "Home"));

        return View(model);
      }
      //return View();
    }

    public IActionResult Privacy() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
