using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Areas.Catalogo.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public CarrosselViewModel(Categoria categoria, IList<Produto> produtos, int numPaginas, int tamanhoPagina)
        {
            Categoria = categoria;
            Produtos = produtos;
            NumPaginas = numPaginas;
            TamanhoPagina = tamanhoPagina;
        }

        public Categoria Categoria { get; set; }
        public IList<Produto> Produtos { get; set; }
        public int NumPaginas { get; set; }
        public int TamanhoPagina { get; set; }
    }
}
