using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraVeiculos.Dominio
{
    public class Veiculo : EntidadeBase
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Ano{ get; set; }
        public  TipoCombustivelEnum TipoCombustivel { get; set; }
        public int GrupoVeiculoId { get; set; }
        public GrupoDeVeiculos.GrupoDeVeiculos? Grupo { get; set; }

        protected Veiculo() { }

        public Veiculo(string modelo, string marca, TipoCombustivelEnum combutivel, string ano, int grupoId)
        {
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            TipoCombustivel = combutivel;
            GrupoVeiculoId = grupoId;
        }
        
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrEmpty(Modelo))
                erros.Add("O Modelo é obrigatorio");

            if (string.IsNullOrEmpty(Marca))
                erros.Add("A Marca é obrigatoria");
            
            if (GrupoVeiculoId == 0)
                erros.Add("O Grupo de Veiculos é obrigatorio");

            return erros;
        }
    }
}