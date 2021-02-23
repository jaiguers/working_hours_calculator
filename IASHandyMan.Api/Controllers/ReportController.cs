using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using IASHandyMan.Api.ApiModel;
using IASHandyMan.CrossCutting.ApplicationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IASHandyMan.Api.Controllers
{
    /// <summary>
    /// Controlador API para calcular horas trabajadas
    /// Autor: Jair Guerrero
    /// Fecha: 2021-02-22
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    public class ReportController : ControllerBase
    {
        private readonly static string INTERNAL_ERROR = "Internal server error";
        private readonly static string SUCCESFULLY = "Creado correctamente";
        private readonly ILogger<ReportController> logger;
        private readonly IPersonServices pServiceBO;


        public ReportController(DomainContext context, ILogger<ReportController> log)
        {
            logger = log;
            pServiceBO = new PersonServicesBO(context);
        }

        /// <summary>
        /// Crear en BD el registro de horas según la atención del técnico
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-22
        /// </summary>
        /// <param name="data">Datos de la horas a guardar</param>
        /// <returns>Json</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult RegisterHours([FromBody] PersonServicesAM data)
        {
            try
            {
                pServiceBO.Create(data);

                return StatusCode(StatusCodes.Status201Created, new JsonResponse { Status = StatusCodes.Status201Created, Title = SUCCESFULLY, TraceId = Guid.NewGuid().ToString() });
            }
            catch (Exception e)
            {
                logger.LogInformation("Error: {mess}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = INTERNAL_ERROR,
                    Errors = new string[] { e.Message },
                    TraceId = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<PersonServicesAM> GetHours(string id)
        {
            try
            {
                return pServiceBO.Get(j => j.IdUser == id);
            }
            catch (Exception e)
            {
                logger.LogInformation("Error: {mess}", e);
                return null;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ReportAM CalculateHours([FromBody] RequestHoursAM data)
        {
            try
            {
                ReportAM report = new ReportAM();
                var workList = pServiceBO.Get(j => j.Person.Identification == data.Identification && j.WeekNumber == data.Week);

                if (workList != null && workList.Count > 0)
                {
                    foreach (PersonServicesAM work in workList.Where(j => j.StarDate.Value.DayOfWeek != DayOfWeek.Sunday))
                    {
                        TimeSpan diff = (work.EndDate.Value - work.StarDate.Value);
                        report.NormalHours += diff.TotalHours;
                    }

                    foreach (PersonServicesAM work in workList.Where(j => j.StarDate.Value.DayOfWeek == DayOfWeek.Sunday))
                    {
                        TimeSpan diff = (work.EndDate.Value - work.StarDate.Value);

                        if (report.NormalHours < 48)
                            report.SundayHours += diff.TotalHours;
                        else
                            report.SundayOvertime += diff.TotalHours;
                    }

                    return report;
                }
                else
                    return new ReportAM();

            }
            catch (Exception e)
            {
                logger.LogInformation("Error: {mess}", e);
                return new ReportAM();
            }
        }
    }
}
