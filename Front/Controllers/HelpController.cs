﻿using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
