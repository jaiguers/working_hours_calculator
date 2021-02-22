using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IASHandyMan.Models;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IASHandyMan.Controllers
{
    public class UtilsController : Controller
    {
        private readonly ILogger<UtilsController> logger;

        public UtilsController(DomainContext context, ILogger<UtilsController> log)
        {
            logger = log;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
