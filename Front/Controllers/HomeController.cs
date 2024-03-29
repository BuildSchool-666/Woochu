﻿using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Front.Models.ViewModels.Home;
using Front.Service.Home;
using Microsoft.AspNetCore.Authorization;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _service;

        public HomeController(ILogger<HomeController> logger, IHomeService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var outputDto = _service.GetIndexData();

            if (!outputDto.IsSuccess)
            {
            };

            var vm =
            outputDto.VM;
            //new IndexVM()
            //{
            //    CityCards = new List<CityCard>
            //        {
            //            new CityCard(){
            //                CityName = "宜蘭",
            //                Price = 250,
            //                ImgUrl = "",

            //                //List<gk41o4> = new  List P{ 
            //                //    new { "海灘" , "fas fa-coffee"},
            //                //    new { "computer" , "fas fa-desktop"},
            //                //}
            //            },
            //            new CityCard(){
            //                CityName = "台北",
            //                Price = 500,
            //                ImgUrl = "",
            //            },
            //        }
            //};

            return View(vm);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult abc()
        {
            return View();
        }
        public IActionResult houseList()
        {
            return View();
        }
        public IActionResult house()
        {
            return View();
        }

    }
}
