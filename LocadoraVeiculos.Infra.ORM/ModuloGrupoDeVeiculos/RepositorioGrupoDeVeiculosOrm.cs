using LocadoraVeiculos.Dominio.GrupoDeVeiculos;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosOrm : RepositorioBaseEmOrm<GrupoDeVeiculos>, IRepositorioGrupoDeVeiculos
    {
        public RepositorioGrupoDeVeiculosOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<GrupoDeVeiculos> ObterRegistros()
        {
            return dbContext.GruposVeiculos;
        }

        public List<GrupoDeVeiculos> Filtrar(Func<GrupoDeVeiculos, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
