﻿using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
