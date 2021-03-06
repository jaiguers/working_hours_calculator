﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IASHandyMan.CrossCutting.ApplicationModel;
using IASHandyMan.Areas.Identity.Models;
using IASHandyMan.Areas.Register.Models;
using Domain.Business.BO;
using Domain.Business.Interface;
using Domain.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace IASHandyMan.Areas.Register.Controllers
{
    [Area("Register")]
    public class RegistersController : Controller
    {
        private readonly ILogger<RegistersController> logger;
        private readonly SignInManager<Users> singInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<Users> userManager;
        private readonly IPerson personBO;

        public RegistersController(DomainContext context, ILogger<RegistersController> log, UserManager<Users> userManag, SignInManager<Users> signInManag, RoleManager<Role> roleManag)
        {
            personBO = new PersonBO(context);
            singInManager = signInManag;
            roleManager = roleManag;
            userManager = userManag;
            logger = log;
        }

        public IActionResult Index()
        {
            RegisterVM model = new RegisterVM();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Person.IdState = 1;
                    model.Person.RegistrationDate = DateTime.Now;

                    var personId = personBO.Create(model.Person);

                    if (personId > 0)
                    {
                        Users user = new Users
                        {
                            Email = model.Email,
                            UserName = model.Email,
                            IdPerson = personId,
                            IdState = 1,
                            IsExternal = true,
                            PasswordChangeDate = DateTime.Now.AddDays(300)
                        };

                        var resultCreated = await userManager.CreateAsync(user);
                        var passwordResult = await userManager.AddPasswordAsync(user, model.Password);
                        var asignRol = await userManager.AddToRoleAsync(user, "Proveedor");
                        // string confirmToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        // string tokenEncode = System.Web.HttpUtility.UrlEncode(confirmToken);

                        return RedirectToAction("Login", "Account", new { area = "Identity" });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + " - /Register/Index");
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult Internal()
        {
            InternalVM model = new InternalVM();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Internal(InternalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Person.IdState = 1;
                    model.Person.RegistrationDate = DateTime.Now;

                    var personId = personBO.Create(model.Person);

                    if (personId > 0)
                    {
                        Users user = new Users
                        {
                            Email = model.Email,
                            UserName = model.Email,
                            IdPerson = personId,
                            IdState = 1,
                            IsExternal = false,
                            PasswordChangeDate = DateTime.Now.AddDays(300)
                        };

                        var resultCreated = await userManager.CreateAsync(user);
                        var passwordResult = await userManager.AddPasswordAsync(user, model.Password);
                        var asignRol = await userManager.AddToRoleAsync(user, "Supervisor");
                        // string confirmToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        // string tokenEncode = System.Web.HttpUtility.UrlEncode(confirmToken);

                        return RedirectToAction("InternalLogin", "Account", new { area = "Identity" });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + " - /Register/Internal");
            }

            return View(model);

        }

    }
}
