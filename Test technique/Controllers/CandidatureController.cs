using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Test_technique.Models;
using Test_technique.Models.Repositories;

namespace Test_technique.Controllers
{
    public class CandidatureController : Controller
    {
        private readonly ICondidatureRepository<Candidature> _condidature;
        private readonly IWebHostEnvironment _hosting;

        public CandidatureController(ICondidatureRepository<Candidature> condidature, IWebHostEnvironment hosting)
        {
            this._condidature = condidature;
            this._hosting = hosting;
        }

        public ActionResult Index()
        {
            var Candidatures = _condidature.List();
            return View(Candidatures);
        }

        public ActionResult Details(Guid id)
        {
            Candidature candidature = _condidature.Find(id);
            return View(candidature);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidature candidature)
        {
            try
            {
                string fileName = string.Empty;
                if (ModelState.IsValid)
                {
                    if (candidature.File != null)
                    {
                        // Créer un dossier contenant le nom complet du candidat dans le répertoire global des CVs
                        string folderName = candidature.Nom.ToUpper() + " " + candidature.Prenom.ToUpper();
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Cvs\" + folderName);
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }

                        // Enregistrer le fichier télécharger dans le dossier
                        string UploadsCvs = Path.Combine(_hosting.WebRootPath, filePath);
                        string extension = Path.GetExtension(candidature.File.FileName);
                        fileName = candidature.Nom.ToUpper() + " " + candidature.Prenom.ToUpper() + extension;
                        string FullPath = Path.Combine(UploadsCvs, fileName);
                        candidature.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                        candidature.CVURL = fileName;
                    }
                }
                _condidature.AjouterCandidature(candidature);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(Guid id)
        {
            Candidature candidature = _condidature.Find(id);
            return View(candidature);
        }

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


        public ActionResult Rechercher(string motRechercher)
        {
            var candidatures = _condidature.List(motRechercher);
            return View("Index", candidatures);
        }

    }
}