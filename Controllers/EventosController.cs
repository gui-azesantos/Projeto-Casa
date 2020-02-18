using System;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoEvento.Data;
using GerenciamentoEvento.DTO;
using GerenciamentoEvento.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEvento.Controllers {

    public class EventosController : Controller {
        private readonly ApplicationDbContext database;

        private readonly UserManager<IdentityUser> _userManager;

        public EventosController (ApplicationDbContext database, UserManager<IdentityUser> userManager) {
            this.database = database;
            _userManager = userManager;
        }

        public IActionResult Home () {
            var eventos = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).ToList ();

            return View (eventos);
        }

        [Authorize]

        public async Task<IActionResult> Index () {

            var eventos = database.Evento.Include (e => e.CasaDeShow).Where (p => p.CasaDeShow.Status == true).ToList ();
            var user = await _userManager.GetUserAsync (User);
            //Condição para validar Admin
            if (user.Email == "admin@gmail.com") {

                return View (eventos);
            } else {
                return Unauthorized ();
            }
        }

        [Authorize]
        public async Task<IActionResult> Criar () {
            ViewBag.CasaDeShow = database.Local.Where (p => p.Status == true).ToList ();
            var user = await _userManager.GetUserAsync (User);

            //Condição para validar a existência de Casas de Show
            var local = database.Local.FirstOrDefault (p => p.Status);
            if (local == null) {
                return View ("Error");
            }
            //Condição para validar Admin
            if (user.Email == "admin@gmail.com") {
                return View ();
            } else {
                return Unauthorized ();
            }
        }

        [Authorize]
        public async Task<IActionResult> Editar (int id) {
            var user = await _userManager.GetUserAsync (User);
            //Condição para validar Admin
            if (user.Email == "admin@gmail.com") {
                if (ModelState.IsValid) {
                    var evento = database.Evento.Include (e => e.CasaDeShow).First (e => e.Id == id);
                    EventoDTO eventoview = new EventoDTO ();
                    eventoview.Id = evento.Id;
                    eventoview.Nome = evento.Nome;
                    eventoview.Capacidade = evento.Capacidade;

                    eventoview.Data = evento.Data;
                    eventoview.Preco = evento.Preco;
                    eventoview.CasaDeShowID = evento.CasaDeShow.Id;
                    eventoview.Estilo = evento.Estilo;
                    eventoview.Imagem = evento.Imagem;
                    ViewBag.CasaDeShow = database.Local.Where (p => p.Status == true).ToList ();
                    return View (eventoview);
                } else {
                    ViewBag.CasaDeShow = database.Local.ToList ();
                    return View ("Editar");
                }
            } else {
                return Unauthorized ();
            }
        }

        [HttpPost]
        public IActionResult Atualizar (EventoDTO _evento) {

            if (ModelState.IsValid) {
                var evento = database.Evento.First (e => e.Id == _evento.Id);
                evento.Nome = _evento.Nome;
                evento.Capacidade = _evento.Capacidade;

                evento.Data = _evento.Data;
                evento.Preco = _evento.Preco;
                evento.CasaDeShow = database.Local.First (casadeshow => casadeshow.Id == _evento.CasaDeShowID);
                evento.Estilo = _evento.Estilo;
                evento.Imagem = _evento.Imagem;
                evento.Status = true;
                database.SaveChanges ();
                return RedirectToAction ("Index", "Eventos");
            } else {
                ViewBag.CasaDeShow = database.Local.Where (p => p.Status == true).ToList ();
                return View ("Editar");
            }

        }

        [HttpPost]
        public IActionResult Salvar (EventoDTO _evento) {

            if (ModelState.IsValid) {

                Evento evento = new Evento ();
                evento.Nome = _evento.Nome;
                evento.Capacidade = _evento.Capacidade;

                evento.Data = _evento.Data;
                evento.Preco = _evento.Preco;
                evento.CasaDeShow = database.Local.First (casadeshow => casadeshow.Id == _evento.CasaDeShowID);
                evento.Estilo = _evento.Estilo;
                evento.Imagem = _evento.Imagem;
                evento.Status = true;
                database.Evento.Add (evento);
                database.SaveChanges ();
                ViewBag.CasaDeShow = database.Local.ToList ();
                return RedirectToAction ("Index", "Eventos");
            } else {
                ViewBag.CasaDeShow = database.Local.Where (p => p.Status == true).ToList ();
                return View ("Criar");
            }

        }

        public async Task<IActionResult> Deletar (int id) {
            var user = await _userManager.GetUserAsync (User);
            //Condição para validar Admin
            if (user.Email == "admin@gmail.com") {
                Evento evento = database.Evento.First (registro => registro.Id == id);
                evento.Status = false;
                database.SaveChanges ();
                return RedirectToAction ("Index");
            } else {
                return Unauthorized ();
            }
        }

        [Authorize]
        //Sistema de Compra 
        public async Task<IActionResult> Compra (int id) {
            var user = await _userManager.GetUserAsync (User);

            //Dados da Compra
            if (ModelState.IsValid) {
                var evento = database.Evento.Include (e => e.CasaDeShow).First (e => e.Id == id);
                VendaDTO compra = new VendaDTO ();
                compra.Id = evento.Id;
                compra.Nome = evento.Nome;
                compra.Capacidade = evento.Capacidade;
                compra.Data = evento.Data;
                compra.Preco = evento.Preco;
                compra.CasaDeShowID = evento.CasaDeShow.Id;
                compra.Estilo = evento.Estilo;
                compra.Imagem = evento.Imagem;

                ViewBag.CasaDeShow = database.Local.Where (p => p.Status == true).ToList ();
                return View (compra);
            } else {
                ViewBag.CasaDeShow = database.Local.ToList ();
                return View ();
            }

        }

        [Authorize]
        public async Task<IActionResult> ConfirmarCompra (VendaDTO _compra, Evento _evento) {
            var user = await _userManager.GetUserAsync (User);

            if (ModelState.IsValid) {
                Venda venda = new Venda ();
                var evento = database.Evento.First (e => e.Id == _evento.Id);
                venda.Nome = _compra.Nome;
                venda.Capacidade = _compra.Capacidade;
                venda.Data = _compra.Data;
                venda.Preco = _compra.Preco;
                venda.CasaDeShow = database.Local.First (casadeshow => casadeshow.Id == _compra.CasaDeShowID);
                venda.Estilo = _compra.Estilo;
                venda.Imagem = _compra.Imagem;
                evento.Capacidade = _evento.Capacidade;
                venda.Qtd = _compra.Qtd;
                venda.Usuario = user.NormalizedUserName;
                database.Venda.Add (venda);

                //Calculo da compra de ingressos 
                if (venda.Qtd > 0 && venda.Qtd <= venda.Capacidade) {
                    venda.Total = venda.Preco * venda.Qtd;
                    evento.Capacidade = (venda.Capacidade - venda.Qtd);
                    database.SaveChanges ();
                }
                //Salvando no banco
                database.Evento.Update (evento);
                database.SaveChanges ();

                ViewBag.CasaDeShow = database.Local.ToList ();
                return RedirectToAction ("Home", "Eventos");
            } else {
                ViewBag.CasaDeShow = database.Local.Where (p => p.Status == true).ToList ();
                return View ("Home");
            }
        }

        [Authorize]
        public async Task<IActionResult> Historico (Venda _compra) {
            var user = await _userManager.GetUserAsync (User);
            var eventos = database.Venda.ToList ();
            ViewBag.CasaDeShow = database.Local.ToList ();
            ViewBag.User = user.NormalizedUserName;

            return View (eventos);

        }

    }
}