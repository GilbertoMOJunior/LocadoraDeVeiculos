using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase
    {
        public Taxa(string nome, TipoCobrancaEnum tipoCobranca, decimal valor)
        {
            Nome = nome;
            TipoCobranca = tipoCobranca;
            Valor = valor;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobranca { get; set; }
        
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Valor < 1)
                erros.Add("O valor deve ser no minimo 1");

            if (Nome.Length < 3)
                erros.Add("O Nome deve ter mais de 3 caracteres");

            return erros;
        }
    }
}
