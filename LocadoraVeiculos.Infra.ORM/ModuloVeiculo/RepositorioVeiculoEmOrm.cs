using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloVeiculo
{
    public class RepositorioVeiculoEmOrm : RepositorioBaseEmOrm<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculoEmOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Veiculo> ObterRegistros()
        {
            return dbContext.Veiculos;
        }

        public List<Veiculo> Filtrar(Func<Veiculo, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Veiculo? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(v => v.Grupo)
                .FirstOrDefault(v => v.Id == id);
        }

        public override List<Veiculo> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(v => v.Grupo)
                .ToList();
        }
    }
}
