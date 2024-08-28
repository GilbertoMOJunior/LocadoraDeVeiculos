using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.NewFolder
{
    public class RepositorioCondutorEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorEmOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Condutor> ObterRegistros()
        {
            return dbContext.Condutores;
        }

        public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
