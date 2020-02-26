using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BHR.Controllers
{
    public class GuidesController : Controller
    {
        
    public IActionResult Buyer() {
      return View();
    }

    public IActionResult Seller() {
      return View();
    }

    public IActionResult Staging() {
      return View();
    }

    public IActionResult Terminology() {
      return View();
    }
  }
}