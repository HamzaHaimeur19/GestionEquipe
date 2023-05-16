using GestionEquipe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace GestionEquipe.Controllers
{
    public class JoueurController : Controller
    {
        public static List<Joueur> listJ = new List<Joueur>()
        {
            new Joueur
            {
                Id = 1,
                Nom = "dzddz",
                Prenom = "dssdd",
                No = 12,
                IdEquipe = 1
            },
             new Joueur
            {
                Id = 2,
                Nom = "EEEZ",
                Prenom = "cdc",
                No = 10,
                IdEquipe = 2
            }
        };
        public static int id = 3;
        public IActionResult Index()
        {
            ViewBag.lj = listJ;
            return View();
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            ViewBag.lE = EquipeController.GetEquipe();
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter([FromForm] Joueur j)
        {
            ViewBag.lE = EquipeController.GetEquipe();
            if (ModelState.IsValid)
            {
                j.Id = id;
                listJ.Add(j);
                id++;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Modifier(int id = 0)
        {

            ViewBag.lE = EquipeController.GetEquipe();
            Joueur j = listJ.Find(j => j.Id == id);
            return View(j);
        }

        [HttpPost]
        public IActionResult Modifier(Joueur joueur)
        {
            ViewBag.lE = EquipeController.GetEquipe();
            Joueur j = listJ.Find(j => j.Id == joueur.Id);
            j.Prenom = joueur.Prenom;
            j.Nom = joueur.Prenom;
            j.No = joueur.No;
            j.IdEquipe = joueur.IdEquipe;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Supprimer(int id = 0)
        {
            Joueur j = listJ.Find(j => j.Id == id);
            listJ.Remove(j);
            return RedirectToAction("Index");
        }

        public static void deleteEquipeById(int IdJoueur)
        {
            List<Joueur> lj = (from j in listJ where j.Id == IdJoueur select j).ToList(); 
            foreach (Joueur j in lj)
            {
                listJ.Remove(j);
            }
        }
        public static List<Joueur> GetJoueur()
        {
            return listJ;
        }
    }
}
