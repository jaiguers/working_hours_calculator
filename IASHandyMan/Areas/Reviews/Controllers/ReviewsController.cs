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
using IASHandyMan.Areas.Reviews.Models;
using IASHandyMan.Api.ApiModel;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace IASHandyMan.Areas.Reviews.Controllers
{
    [Area("Reviews")]
    public class ReviewsController : BaseController
    {
        private readonly ILogger<ReviewsController> logger;
        private readonly IPersonServices pServiceBO;

        public IConfiguration Configuration { get; }

        public ReviewsController(DomainContext context, ILogger<ReviewsController> log, UserManager<Users> userManag, RoleManager<Role> roleManag, IConfiguration configuration) : base(userManag, roleManag, context)
        {
            logger = log;
            pServiceBO = new PersonServicesBO(context);
            Configuration = configuration;
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public IActionResult Index(RequestHoursVM data)
        {
            TempData["modelData"] = JsonConvert.SerializeObject(data);

            return RedirectToAction("Calculate", "Reviews");
        }

        [HttpGet]
        [Authorize(Roles = RolesEnum.SUPERVISOR + "," + RolesEnum.ADMIN)]
        public async Task<IActionResult> CalculateAsync()
        {
            var data = JsonConvert.DeserializeObject<RequestHoursVM>((string)TempData["modelData"]);
            ReportVM model = null;
            RequestHoursAM request = new RequestHoursAM { Identification = data.Identification, Week = data.Week };
            var apiEndpoint = Configuration["ApiEndpoint"];
            var apiClient = new HttpClient();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await apiClient.PostAsync(apiEndpoint + "/api/Report/CalculateHours", content);

            if (response.IsSuccessStatusCode)
            {
                var strJson = await response.Content.ReadAsStringAsync();
                var deserialize = JsonConvert.DeserializeObject<ReportAM>(strJson);
                model = new ReportVM
                {
                    NormalHours = deserialize.NormalHours,
                    SundayHours = deserialize.SundayHours,
                    NightHours = deserialize.NightHours,
                    NormalOvertime = deserialize.NormalOvertime,
                    NightOvertime = deserialize.NightOvertime,
                    SundayOvertime = deserialize.SundayOvertime
                };
            }

            return View(model);
        }
    }
}
