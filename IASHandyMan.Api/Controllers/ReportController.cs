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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ReportController : ControllerBase
    {
        private readonly static string INTERNAL_ERROR = "Internal server error";
        private readonly static string SUCCESFULLY = "Creado correctamente";
        private readonly ILogger<ReportController> logger;
        private readonly IPersonServices pServiceBO;
        private readonly IServices servicesBO;


        public ReportController(DomainContext context, ILogger<ReportController> log)
        {
            logger = log;
            pServiceBO = new PersonServicesBO(context);
            servicesBO = new ServicesBO(context);
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
        [EnableCors(origins: "http://localhost:53585", headers: "*", methods: "*")]
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
        [Route("[action]")]
        public IActionResult CalculateHours()
        {
            try
            {

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
    }
}
