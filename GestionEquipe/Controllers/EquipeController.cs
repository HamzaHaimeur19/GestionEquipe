using GestionEquipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEquipe.Controllers
{
    public class EquipeController : Controller
    {
        public static List<Equipe> listE = new List<Equipe>()
        {
            new Equipe
            {
                Id = 1,
                Pays = "Maroc",
                nbrParticipation = 4
            },
             new Equipe
            {
                Id = 2,
                Pays = "Senegal",
                nbrParticipation = 5
            }
        };
        public static int id = 3;
        public IActionResult Index()
        {
            ViewBag.le = listE;
            return View();
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter([FromForm] Equipe e)
        {
            if (ModelState.IsValid)
            {          
                e.Id = id;
                listE.Add(e);
                id++;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Modifier(int id = 0)
        {
            Equipe e = listE.Find(e => e.Id == id);
            return View(e);
        }

        [HttpPost]
        public IActionResult Modifier(Equipe equipe)
        {
            Equipe e = listE.Find(e => e.Id == equipe.Id);
            e.Pays = equipe.Pays;
            e.nbrParticipation = equipe.nbrParticipation;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Supprimer(int id=0)
        {
            Equipe e = listE.Find(e => e.Id == id);
            listE.Remove(e);
            JoueurController.deleteEquipeById(id);
            return RedirectToAction("Index");
        }

    
        public static List<Equipe> GetEquipe()
        {
            return listE;
        }

    }
    
}
