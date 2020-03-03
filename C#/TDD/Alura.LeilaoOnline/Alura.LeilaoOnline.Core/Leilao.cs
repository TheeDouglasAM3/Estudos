using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        public enum EstadoLeilao
        {
            LeilaoAntesDoPregao,
            LeilaoEmAndamento,
            LeilaoFinalizado
        }
        
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }
        private IModalidadeAvaliacao _modalidade;
        private IList<Lance> _lances;
        private Interessada _ultimoCliente;


        public Leilao(string peca, IModalidadeAvaliacao modalidade)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
            _modalidade = modalidade;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
                throw new InvalidOperationException("Não é possível terminar o pregão sem que ele seja iniciado.");

            Ganhador = _modalidade.Avalia(this);
            Estado = EstadoLeilao.LeilaoFinalizado;
        }

        private bool NovoLanceEhAceito(Interessada cliente)
        {
            return Estado == EstadoLeilao.LeilaoEmAndamento
                && cliente != _ultimoCliente;
        }
    }
}
