﻿using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class HostingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult host()
        {
            return View();
        }
    }
}
