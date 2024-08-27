using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.GrupoDeVeiculos
{
    public class GrupoDeVeiculos : EntidadeBase
    {
        protected GrupoDeVeiculos()
        {
        }

        public GrupoDeVeiculos(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; } = [];

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Nome.Length == 0)
                erros.Add("O nome é obrigatório");
            return erros;
        }
    }
}