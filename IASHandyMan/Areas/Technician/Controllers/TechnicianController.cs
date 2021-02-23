using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using IASHandyMan.Areas.Admin.Controllers;
using IASHandyMan.Areas.Identity.Models;
using IASHandyMan.Areas.Technician.Models;
using IASHandyMan.Controllers;
using IASHandyMan.CrossCutting.ApplicationModel;
using IASHandyMan.CrossCutting.Enumerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private readonly IServices servicesBO;
        private readonly IPersonServices pServiceBO;

        public IConfiguration Configuration { get; }


        public TechnicianController(DomainContext context, ILogger<UsersController> log, UserManager<Users> userManag, RoleManager<Role> roleManag, IConfiguration configuration) : base(userManag, roleManag, context)
        {
            logger = log;
            userManager = userManag;
            roleManager = roleManag;
            Configuration = configuration;
            servicesBO = new ServicesBO(context);
            pServiceBO = new PersonServicesBO(context);
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.TECH + "," + RolesEnum.ADMIN)]
        public async Task<IActionResult> IndexAsync()
        {
            var apiEndpoint = Configuration["ApiEndpoint"];
            var apiClient = new HttpClient();
            PersonServicesVM model = new PersonServicesVM();

            var response = apiClient.GetAsync(apiEndpoint + "/api/Report/GetHours/" + AuthUser.Id).Result;

            if (response.IsSuccessStatusCode)
            {
                var strJson = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<IEnumerable<PersonServicesAM>>(strJson);
                model.PersonServiceList = (List<PersonServicesAM>)deserialize;
            }

            return View(model);
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
                var apiEndpoint = Configuration["ApiEndpoint"];
                var apiClient = new HttpClient();

                int result = DateTime.Compare(model.EndDate.Value, model.StarDate.Value);

                if (result < 0)
                {
                    ModelState.AddModelError("StarDate", "La fecha de inicio debe ser menor que la fecha de fin.");
                    return View(model);
                }

                var service = servicesBO.GetFirst(j => j.Identification == model.Services.Identification);

                model.IdUser = AuthUser.Id;
                model.IdPerson = AuthUser.IdPerson.Value;
                model.IdServices = service.Id;
                model.Services = null;

                var currentCulture = CultureInfo.CurrentCulture;
                model.WeekNumber = currentCulture.Calendar.GetWeekOfYear(
                                model.StarDate.Value,
                                currentCulture.DateTimeFormat.CalendarWeekRule,
                                currentCulture.DateTimeFormat.FirstDayOfWeek);

                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await apiClient.PostAsync(apiEndpoint + "/api/Report/RegisterHours", content);

                if (response.IsSuccessStatusCode)
                    CreateModal("exito", "Terminado", "Las horas se han registrado satisfactoriamente.", "Terminar", null, "Redirect('Index')", null);

            }

            return View();
        }
    }
}
