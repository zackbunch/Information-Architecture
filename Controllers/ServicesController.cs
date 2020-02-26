using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BHR.Controllers {
  public class ServicesController : Controller {
    public IActionResult Index() {
      return View();
    }

    public IActionResult Buying() {
      return View();
    }

    public IActionResult Selling() {
      return View();
    }

    public IActionResult Staging() {
      return View();
    }
  }
}