using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_technique.Models;
using Test_technique.Models.Repositories;

namespace Test_technique.Controllers
{
    public class CandidatureController : Controller
    {
        private readonly ICondidatureRepository<Candidature> _condidature;

        public CandidatureController(ICondidatureRepository<Candidature> condidature)
        {
            this._condidature = condidature;
        }
        
        public IActionResult AffichierResumer(Guid id)
        {
            Candidature candidature = _condidature.Find(id);
            return View("Details", candidature);
        }
        
        // GET: CandidatureController
        public ActionResult Index()
        {
            var Candidatures = _condidature.List();
            return View(Candidatures);
        }

        // GET: CandidatureController/Details/5
        public ActionResult Details(Guid id)
        {
            Candidature candidature = _condidature.Find(id);
            return View(candidature);
        }

        // GET: CandidatureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidatureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidature candidature)
        {
            try
            {
                _condidature.AjouterCandidature(candidature);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidatureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatureController/Delete/5
        public ActionResult Delete(Guid id)
        {
            Candidature candidature = _condidature.Find(id);
            return View(candidature);
        }

        // POST: CandidatureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Candidature candidature)
        {
            try
            {
                _condidature.SupprimerCandidature(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}