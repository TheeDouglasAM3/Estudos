using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Services
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            //chama as migrations do banco
            contexto.Database.Migrate();
            List<Livro> livros = GetLivros();
            produtoRepository.SaveProdutos(livros);
        }

        

        private static List<Livro> GetLivros()
        {
            //pega o arquivo json
            var json = File.ReadAllText("Datas\\livros.json");
            //transformas os dados em json em objeto
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
