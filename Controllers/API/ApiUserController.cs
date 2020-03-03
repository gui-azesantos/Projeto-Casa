using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GerenciamentoEvento.Data;
using GerenciamentoEvento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers {
    [Route ("api/v1/user")]
    [ApiController]
    public class ApiUserController : ControllerBase {

        private readonly ApplicationDbContext database;

        public ApiUserController (ApplicationDbContext database) {

            this.database = database;
        }

        [HttpGet]
        public IActionResult Get () {
            var user = database.Users.ToList ();
            return Ok (user); //Status code = 200 && Dados 
        }
    }
}