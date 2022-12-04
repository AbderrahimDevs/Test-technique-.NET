using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_technique.Models.Repositories
{
    public class CandidatureDBRepository : ICondidatureRepository<Candidature>
    {
        private readonly CandidatureDBContext _db;

        public CandidatureDBRepository(CandidatureDBContext db)
        {
            this._db = db;
        }

        public IList<Candidature> ListCandidatures { get; set; }

        public void AjouterCandidature(Candidature candidature)
        {
            _db.Candidatures.Add(candidature);
            _db.SaveChanges();
        }

        public Candidature Find(Guid id)
        {
            Candidature candidature = _db.Candidatures.FirstOrDefault(c => c.CondidatureID == id);
            return candidature;
        }

        public IList<Candidature> List()
        {
            return _db.Candidatures.ToList();
        }

        public IList<Candidature> List(string MotRechercher)
        {
            List<Candidature> liste = _db.Candidatures.Where(c => c.Nom.Contains(MotRechercher) || c.Prenom.Contains(MotRechercher) || c.Mail.Contains(MotRechercher) || c.Telephone.Contains(MotRechercher)).ToList();
            return liste;
        }

        public void SupprimerCandidature(Guid id)
        {
            Candidature candidature = Find(id);
            _db.Remove(candidature);
            _db.SaveChanges();
        }
    }
}