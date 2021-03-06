﻿using System;
using BlingRus.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlingRus.Web.Controllers
{
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            var model = new ContactRequestModel();
            return View(model);
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactRequestModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return View("ThankYou");
        }
    }
}
