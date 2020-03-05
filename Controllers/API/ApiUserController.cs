using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using GerenciamentoEvento.Data;
using GerenciamentoEvento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiRest.Controllers
{
    [Route ("api/v1/user")]
    [ApiController]
    public class ApiUserController : ControllerBase {

        private readonly ApplicationDbContext database;

        public ApiUserController (ApplicationDbContext database) {

            this.database = database;
        }

        [HttpGet]
        public IActionResult Get () {
            var user = database.Usuario.Select (p => p.Email).ToList ();
            return Ok (user); //Status code = 200 && Dados 
        }

        [HttpGet ("{id}")]

        public IActionResult Get (int id) {
            try {
                var user = database.Usuario.First (p => p.Id == id).Email;
                return Ok (user); //Status code = 200 && Dados 
            } catch (System.Exception) {
                Response.StatusCode = 404;
                return new ObjectResult ("");
            }

        }

        [HttpPost ("Cadastro")]
        public IActionResult Cadastro ([FromBody] Usuario user) {
            try {
                database.Add (user);
                database.SaveChanges ();
                return Ok ((new { msg = "Usuário cadastrado com sucesso" }));
            } catch (Exception) {
                return BadRequest ((new { msg = "Requisição Inválida" }));
            }
        }

        [HttpPost ("Login")]
        public IActionResult Login ([FromBody] Usuario credenciais) {
            try {
                var user = database.Usuario.First (p => p.Email.Equals (credenciais.Email));
                if (user != null) {
                    //Achou usuário
                    if (user.Senha.Equals (credenciais.Senha)) {
                        //Usuário inseriu credenciais corretas => Logou!
                        string Key = "ProjetoApiEvento.com";
                        var KeySimetrica = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Key));
                        var KeyAcesso = new SigningCredentials (KeySimetrica, SecurityAlgorithms.HmacSha256Signature);

                        var TokenJwt = new JwtSecurityToken (
                            issuer: "Eventos.com", //Quem está fornecendo o Jwt
                            expires : DateTime.Now.AddHours (1),
                            audience: "Admin",
                            signingCredentials : KeyAcesso
                           /*  claims : claims */
                        );
                     Response.StatusCode = 200;
                    return new ObjectResult ("Você está Logado! \t" + new JwtSecurityTokenHandler().WriteToken(TokenJwt));
                    } else {
                        //Não existe nenhum usuário
                        Response.StatusCode = 401;
                        return new ObjectResult ("");
                    }
                } else {
                    Response.StatusCode = 401;
                    return new ObjectResult ("");
                }
            } catch (Exception) {
                Response.StatusCode = 400;
                return new ObjectResult ("");;
            }
        }

    }
}