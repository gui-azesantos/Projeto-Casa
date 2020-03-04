using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GerenciamentoEvento.Data;
using GerenciamentoEvento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers {
    [Route ("api/v1/eventos")]
    [ApiController]
    public class ApiEventosController : ControllerBase {

        private readonly ApplicationDbContext database;

        public ApiEventosController (ApplicationDbContext database) {

            this.database = database;
        }

        [HttpGet]
        public IActionResult Get () {
            var eventos = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).Where (p => p.CasaDeShow.Status == true).ToList ();
            return Ok (eventos); //Status code = 200 && Dados 
        }

        [HttpGet ("capacidade/asc")]
        public IActionResult GetAsc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderBy (p => p.Capacidade);
            return Ok (local);
            //Status code = 200 && Dados 

        }

        [HttpGet ("capacidade/desc")]
        public IActionResult GetDesc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderByDescending (p => p.Capacidade);
            return Ok (local);
            //Status code = 200 && Dados 

        }

        [HttpGet ("data/asc")]
        public IActionResult GetDataAsc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderBy (p => p.Data);
            return Ok (local);
            //Status code = 200 && Dados 

        }

        [HttpGet ("data/desc")]
        public IActionResult GetDataDesc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderByDescending (p => p.Data);
            return Ok (local);
            //Status code = 200 && Dados 
        }

        [HttpGet ("preco/asc")]
        public IActionResult GetPrecoAsc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderBy (p => p.Preco);
            return Ok (local);
            //Status code = 200 && Dados 

        }

        [HttpGet ("preco/desc")]
        public IActionResult GetPrecoDesc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderByDescending (p => p.Preco);
            return Ok (local);
            //Status code = 200 && Dados 
        }

        [HttpGet ("nome/asc")]
        public IActionResult GetNomeAsc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderBy (p => p.Nome);
            return Ok (local);
        }

        [HttpGet ("nome/desc")]
        public IActionResult GetNomeDesc () {
            var local = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (p => p.Status == true).ToList ().OrderByDescending (p => p.Nome);
            return Ok (local);
        }

        [HttpGet ("{id}")]
        public IActionResult Get (int id) {
            try {
                Evento evento = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).Where (e => e.Status == true).First (p => p.Id == id);
                return Ok (evento);
            } catch (Exception) {

                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }

        }

        [HttpGet ("vendas")]
        public IActionResult GetUser () {
            var local = database.Venda.Include (e => e.CasaDeShow).ToList ().OrderByDescending (p => p.Nome);
            return Ok (local);
        }

        [HttpGet ("vendas/" + "{id}")]
        public IActionResult GetUser (int id) {
            try {
                Venda venda = database.Venda.Include (e => e.CasaDeShow).First (p => p.Id == id);
                return Ok (venda);
            } catch (Exception) {

                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }
        }

        [HttpPost]
        public IActionResult Post ([FromBody] EventoTemp eTemp) {
            //Validação

            Evento e = new Evento ();
            e.Nome = eTemp.Nome;
            e.Capacidade = eTemp.Capacidade;
            e.Data = eTemp.Data;
            e.Preco = eTemp.Preco;
            if (database.Local.First (c => c.Id == eTemp.CasaDeShowID) == null || database.Local.Where (c => c.Status == true).First (c => c.Id == eTemp.CasaDeShowID) == null) {
                return new ObjectResult (new { msg = "O local do Evento não existe!" });
            } else {
                e.CasaDeShow = database.Local.First (c => c.Id == eTemp.CasaDeShowID);
            }
            e.Estilo = eTemp.Estilo.ToString ();
            e.Imagem = eTemp.Imagem;
            e.Status = eTemp.Status;
            database.Evento.Add (e);
            database.SaveChanges ();

            //Set do Status Code
            Response.StatusCode = 201;
            return new ObjectResult (new { msg = "Evento criado com sucesso!" });
        }

        [HttpPatch]
        public IActionResult Patch ([FromBody] EventoTemp ptemp) {
            if (ptemp.Id > 0) {

                try {
                    var evento = database.Evento.First (p => p.Id == ptemp.Id);
                    if (ptemp != null) {

                        //Editar 
                        evento.Nome = ptemp.Nome != null ? ptemp.Nome : evento.Nome;
                        evento.Capacidade = ptemp.Capacidade != 0 ? ptemp.Capacidade : evento.Capacidade;
                        evento.Data = ptemp.Data != null ? ptemp.Data : evento.Data;
                        evento.Preco = ptemp.Preco != 0 ? ptemp.Preco : evento.Preco;
                        if (ptemp.CasaDeShowID != 0) {
                            evento.CasaDeShow = database.Local.First (p => p.Id == ptemp.CasaDeShowID);
                        } else {
                            evento.CasaDeShow = evento.CasaDeShow;
                        }
                       if(evento.Estilo == ptemp.Estilo.ToString()){
                           evento.Estilo = evento.Estilo;
                       }else{
                           evento.Estilo = ptemp.Estilo.ToString();
                       }
                        evento.Imagem = ptemp.Imagem != null ? ptemp.Imagem : evento.Imagem;
                        database.SaveChanges ();
                        return Ok ();
                    }
                } catch (System.Exception) {
                    Response.StatusCode = 404;
                    return new ObjectResult (new { msg = "Evento não encontrado" });
                }

            } else {
                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }
            Response.StatusCode = 404;
            return new ObjectResult (new { msg = "Id inválido" });
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (int id) {
            try {
                var evento = database.Evento.First (p => p.Id == id);
                evento.Status = false;
                database.SaveChanges ();
                Response.StatusCode = 201;
                return new ObjectResult (new { msg = "Evento excluido!" });
            } catch (Exception) {
                Response.StatusCode = 404;
                return new ObjectResult (new { msg = "Id inválido" });
            }
        }

        public class EventoTemp {
            public int Id { get; set; }

            [Required (ErrorMessage = "O Nome é obrigatório.")]
            [StringLength (150, ErrorMessage = "Nome grande demais.")]
            [MinLength (2, ErrorMessage = "Nome curto demais.")]
            public string Nome { get; set; }

            [Range (10, 100000, ErrorMessage = "Capacidade Inválida.")]
            public int Capacidade { get; set; }

            [Required (ErrorMessage = "A data é obrigatória.")]
            public System.DateTime Data { get; set; }

            [Range (1, 100000, ErrorMessage = "Preço inválido.")]
            public double Preco { get; set; }

            [Required]

            public int CasaDeShowID { get; set; }

            [Range (0, 8, ErrorMessage = "Estilo inválido.")]
            public int Estilo { get; set; }

            [Required (ErrorMessage = "A URL da imagem é obrigatória.")]
            [MinLength (2, ErrorMessage = "Url curta demais.")]
            [StringLength (1024, ErrorMessage = "Url grande demais.")]
            public string Imagem { get; set; }

            public bool Status { get; set; }
        }
    }
}