using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace MVCFilmes2025.Controllers
{
    public class FilmesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BemVindo(string nome, int id)
        {
            ViewData["Title"] = "Boas vindas!";
            ViewData["Nome"] = nome;
            ViewData["id"] = id;
            //string bemvindo = $"Olá! Seja bem-vindo {nome} - {id}!";
            return View();
        }
    }
}
