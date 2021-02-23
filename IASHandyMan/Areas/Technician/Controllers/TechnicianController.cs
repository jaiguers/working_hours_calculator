using Domain.Context;
using IASHandyMan.Areas.Admin.Controllers;
using IASHandyMan.Areas.Identity.Models;
using IASHandyMan.Controllers;
using IASHandyMan.CrossCutting.ApplicationModel;
using IASHandyMan.CrossCutting.Enumerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        [Authorize(Roles = RolesEnum.TECH + "," + RolesEnum.ADMIN)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.TECH)]
        public IActionResult RegisterHours()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RolesEnum.TECH)]
        public async Task<IActionResult> RegisterHours(PersonServicesAM model)
        {
            if (ModelState.IsValid)
            {
                int result = DateTime.Compare(model.EndDate.Value, model.StarDate.Value);

                if (result < 0)
                {
                    ModelState.AddModelError("StarDate", "La fecha de inicio debe ser menor que la fecha de fin.");
                    return View(model);
                }

                var apiClient = new HttpClient();
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await apiClient.PostAsync("http://localhost:57088/api/Report/RegisterHours", content);

                if (response.IsSuccessStatusCode)
                    CreateModal("exito", "Terminado", "Las horas se han registrado satisfactoriamente.", "Terminar", null, "Redirect('Index')", null);

            }

            return View();
        }
    }
}
