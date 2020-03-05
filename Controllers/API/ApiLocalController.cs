using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using GerenciamentoEvento.Data;
using GerenciamentoEvento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Casa.Controllers.API {

    [Route ("api/v1/local")]
    [ApiController]

    public class ApiLocalController : ControllerBase {
        private readonly ApplicationDbContext database;

        public ApiLocalController (ApplicationDbContext database) {

            this.database = database;
        }

        [HttpGet]
        public IActionResult Get () {
            var local = database.Local.Where (p => p.Status == true).ToList ();
            return Ok (local);
            //Status code = 200 && Dados 
        }

        [HttpGet ("asc")]
        public IActionResult GetAsc () {
            var local = database.Local.Where (p => p.Status == true).ToList ().OrderBy (p => p.Nome);
            return Ok (local);
            //Status code = 200 && Dados 

        }

        [HttpGet ("desc")]
        public IActionResult GetDesc () {
            var local = database.Local.Where (p => p.Status == true).ToList ().OrderByDescending (p => p.Nome);
            return Ok (local);
            //Status code = 200 && Dados 

        }

        [HttpGet ("{id}")]
        public IActionResult GetId (int id) {
            try {
                var local = database.Local.Where (l => l.Status == true).First (l => l.Id == id);
                return Ok (local);
            } catch (Exception) {

                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }

        }

        [HttpGet ("nome/" + "{nome}")]
        public IActionResult GetNome (string nome) {
            try {

                var local = database.Local.Where (l => l.Status == true).First (l => l.Nome == nome);
                return Ok (local);
            } catch (Exception) {

                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Nome inválido" });
            }

        }

        [Authorize]
        [HttpPost]

        public IActionResult Post ([FromBody] LocalTemp lTemp) {
            try {
                Local l = new Local ();
                l.Nome = lTemp.Nome;
                l.Endereco = lTemp.Endereco;
                l.LinkEndereco = lTemp.LinkEndereco;
                l.Status = true;
                database.Local.Add (l);
                database.SaveChanges ();

                //Set do Status Code
                Response.StatusCode = 201;
                return new ObjectResult (new { msg = "Local criado com sucesso!" });
            } catch {
                return  BadRequest (new { msg = "Id inválido" });
            }
        }

        [Authorize]
        [HttpPatch]

        public IActionResult Patch ([FromBody] LocalPatch ltemp) {
            if (ltemp.Id > 0) {

                try {
                    var local = database.Local.First (p => p.Id == ltemp.Id);
                    if (ltemp != null) {

                        //Editar 

                        if (ltemp.Nome != null) {
                            if (ltemp.Nome.Length > 0 && ltemp.Nome.Length < 100) {
                                local.Nome = ltemp.Nome;
                            } else {
                                Response.StatusCode = 404;
                                return new ObjectResult (new { msg = "Nome  inválido" });
                            }
                        }

                        if (ltemp.Endereco != null) {
                            if (ltemp.Endereco.Length > 0 && ltemp.Endereco.Length < 100) {
                                local.Endereco = ltemp.Endereco;
                            } else {
                                Response.StatusCode = 404;
                                return new ObjectResult (new { msg = "Endereço  inválido" });
                            }
                        }
                        if (ltemp.Endereco != null) {
                            if (ltemp.LinkEndereco.Length > 0 && ltemp.LinkEndereco.Length < 1024) {
                                local.LinkEndereco = ltemp.LinkEndereco;
                            } else {
                                Response.StatusCode = 404;
                                return new ObjectResult (new { msg = "Endereço  inválido" });
                            }
                        }
                        database.SaveChanges ();
                        return Ok ();
                    }
                } catch (System.Exception) {
                    Response.StatusCode = 404;
                    return new ObjectResult (new { msg = "Local não encontrado" });
                }

            } else {
                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }
            Response.StatusCode = 404;
            return new ObjectResult (new { msg = "Id inválido" });
        }

        [Authorize]
        [HttpDelete ("{id}")]

        public IActionResult Delete (int id) {
            try {
                var local = database.Local.First (p => p.Id == id);
                local.Status = false;
                database.SaveChanges ();
                Response.StatusCode = 201;
                return new ObjectResult (new { msg = "Local excluido!" });
            } catch (Exception) {

                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }
        }
        public class LocalTemp {

            [Required]
            public int Id { get; set; }

            [Required (ErrorMessage = "O Nome é obrigatório.")]
            public string Nome { get; set; }

            [Required (ErrorMessage = "O Endereço é obrigatório.")]
            public string Endereco { get; set; }

            public string LinkEndereco { get; set; }

            public bool Status { get; set; }
        }
        public class LocalPatch {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string LinkEndereco { get; set; }

        }
    }

}