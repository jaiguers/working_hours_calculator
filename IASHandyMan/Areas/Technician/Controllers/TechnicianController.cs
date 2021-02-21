using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Context;
using IASHandyMan.Areas.Admin.Controllers;
using IASHandyMan.Areas.Identity.Models;
using IASHandyMan.Controllers;
using IASHandyMan.CrossCutting.Enumerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IASHandyMan.Areas.Technician.Controllers
{
    [Area("Technician")]
    public class TechnicianController : BaseController
    {
        private readonly ILogger<UsersController> logger;
        private readonly UserManager<Users> userManager;
        private readonly RoleManager<Role> roleManager;

        public TechnicianController(DomainContext context, ILogger<UsersController> log, UserManager<Users> userManag, RoleManager<Role> roleManag) : base(userManag, roleManag, context)
        {
            logger = log;
            userManager = userManag;
            roleManager = roleManag;
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.TECH)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
