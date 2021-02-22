using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using IASHandyMan.CrossCutting.ApplicationModel;
using Microsoft.AspNetCore.Authorization;
using IASHandyMan.CrossCutting.Enumerators;
using IASHandyMan.Models;
using System.Security.Cryptography;
using System.IO;
using IASHandyMan.Controllers;
using Microsoft.AspNetCore.Identity;
using IASHandyMan.Areas.Identity.Models;

namespace IASHandyMan.Areas.Reviews.Controllers
{
    [Area("Reviews")]
    public class ReviewsController : BaseController
    {
        private readonly ILogger<ReviewsController> logger;
       
        public ReviewsController(DomainContext context, ILogger<ReviewsController> log, UserManager<Users> userManag, RoleManager<Role> roleManag) : base(userManag, roleManag, context)
        {
            logger = log;
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public IActionResult Index()
        {
            return View();
        }


        
    }
}
