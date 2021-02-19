using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using IASHandyMan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using IASHandyMan.Areas.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Business.Interface;
using Domain.Context;
using Domain.Business.BO;

namespace IASHandyMan.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> log, UserManager<Users> userManag, RoleManager<Role> roleManag, DomainContext context)
            : base(userManag, roleManag, context)
        {
            logger = log;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IdUsers") != null)
            {
                logger.LogInformation("Info: {msg}", "/Home/Index");
                return RedirectToAction("Dashboard", "Home", new { area = "" });
            }
            else
                return RedirectToAction("Login", "Account", new { area = "Identity" });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
