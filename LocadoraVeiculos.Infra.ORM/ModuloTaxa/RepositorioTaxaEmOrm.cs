using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloTaxa
{
    public class RepositorioTaxaEmOrm : RepositorioBaseEmOrm<Taxa>, IRepositorioTaxa
    {
        public RepositorioTaxaEmOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Taxa> ObterRegistros()
        {
            return dbContext.Taxas;
        }

        public List<Taxa> Filtrar(Func<Taxa, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
