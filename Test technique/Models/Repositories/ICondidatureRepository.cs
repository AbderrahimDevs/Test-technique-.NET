using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_technique.Models.Repositories
{
    public interface ICondidatureRepository<TEntity>
    {
        IList<TEntity> List();
        IList<TEntity> List(string MotRechercher);

        TEntity Find(Guid id);

        void AjouterCandidature(TEntity entity);
        void SupprimerCandidature(Guid id);
    }
}
